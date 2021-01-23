    public void SaveScore()
    {
    
        bool canContinue = false;
        ParseObject SendScore = new ParseObject("Scores");
        SendScore["Score"] = CheckAnswer.score;
        SendScore["user"] = ParseObject.CreateWithoutData("_User", ParseUser.CurrentUser.ObjectId);
        SendScore["TestMode"] = MainMenu.testmode;
        SendScore["TotalQuestions"] = QuestionCreation.TotalQuestions;
        SendScore["CorrectQuestions"] = CheckAnswer.CorrectQuestions;
    
    
        SendScore.SaveAsync().ContinueWith(t =>
        {
            ScoreObjectId = SendScore.ObjectId;
            //set the bool canContinue to true because the first portion of code has finished running
            canContinue = true;
        });
        //wait while the canContinue bool is false
        while(!canContinue){
            yield return null;
        }
        //continue your parse code
        ParseObject SendCorrectTopics = new ParseObject("CorrectAnswers");
        SendCorrectTopics["Score"] = SendScore.ObjectId;
        for (int i = 0; i <= 9; i++)
        {
            string Topic = "Topic" + (i + 1).ToString();
            SendCorrectTopics[Topic] = CheckAnswer.CorrectTopics[i];
        }
    
        SendCorrectTopics.SaveAsync();
    
        SceneManager.LoadScene(0);
    }
