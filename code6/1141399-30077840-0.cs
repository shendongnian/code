    public void PlayerWin()
        {
            gameOver = true;
    
            //Update the highscore
            float bestTime = 0;
            bool isNewHighscore = false;
    
            if (gameTime < PlayerPrefs.GetFloat("Best Time"))
            {
                PlayerPrefs.SetFloat("Best Time", gameTime);
            }
            //TODO: Not sure if I have done this correct trying to complete the code to read and store the highscore
    
            bestTime = PlayerPrefs.GetFloat("Best Time"); // ADD THIS LINE HERE
            //Pop up the win message
            UIController.GameOver(WIN_MESSAGE, gameTime, bestTime, isNewHighscore);
        }
