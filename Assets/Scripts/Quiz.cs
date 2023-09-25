using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO questions;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    Image buttonImage
    void Start()
    {
       DisplayQuestion();
     }
    public void OnAnswerSelected(int index){

        if(index == questions.GetCorrectAnswerIndex()){
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        } else {
            correctAnswerIndex = questions.GetCorrectAnswerIndex();
            string correctAnswer = questions.GetAnswer(correctAnswerIndex);
            questionText.text = "Incorrect! The correct answer was " + correctAnswer;
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;

        }
        SetButtonState(false);
    }
    public void DisplayQuestion(){
        questionText.text = questions.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++){
            TextMeshProUGUI buttontext = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttontext.text = questions.GetAnswer(i);
        }
        
    }
    void GetNextQuestion(){
        DisplayQuestion();
        SetDefaultButtonSprites();
        SetButtonState(true);
    }
    void SetButtonState (bool state){
        for(int i = 0; i < answerButtons.Length; i++){
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}
    void SetDefaultButtonSprites(){
        for(int i = 0; i < answerButtons.Length; i++){
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }