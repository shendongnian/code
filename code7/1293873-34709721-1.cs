        public void SaveScore()
    {
        ParseObject SendScore = new ParseObject("Scores");
        SendScore["Score"] = CheckAnswer.score;
        SendScore["user"] = ParseObject.CreateWithoutData("_User", ParseUser.CurrentUser.ObjectId);
        SendScore["TestMode"] = MainMenu.testmode;
        SendScore["TotalQuestions"] = QuestionCreation.TotalQuestions;
        SendScore["CorrectQuestions"] = CheckAnswer.CorrectQuestions;
        Task SendingScores = SendScore.SaveAsync().ContinueWith(t =>
        {
            if (t.IsFaulted || t.IsCanceled)
            {
                DoneSave = false;
                print(t.Exception);
            }
            else
            {
                DoneSave = true;
                print("Setting object ID!");
                ScoreObjectId = SendScore.ObjectId;
                print(ScoreObjectId); 
            }
        });
    }
   
    void SaveTotalTopics()
    {
        for (int i = 0; i <= 9; i++)
        {
            string Topic = "Topic" + (i + 1).ToString();
            SendCorrectTopics[Topic] = CheckAnswer.CorrectTopics[i];
        }
        SendCorrectTopics["UserScore"] = ParseObject.CreateWithoutData("Scores", ScoreObjectId);
        SendCorrectTopics.SaveAsync().ContinueWith(t =>
        {
            if(t.IsFaulted || t.IsCanceled)
            {
                print(t.Exception);
            }
            else
            {
                print("Saved!");
            }
        });
    }
