    public void checkAnswer(int answerID)
    {
        if(answerID == currentQuestion.correctAnswerID)
        {
            // answer was correct
            Debug.Log("correct");
        }
        else
        {
            // answer was wrong
            Debug.Log("wrong");
        }
        SetNewQuestion();
    }
