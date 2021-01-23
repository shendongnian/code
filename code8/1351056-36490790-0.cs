        private bool CheckIfCorrect(byte questionNum, string answers, string userAnswer)
            {
                int adjustmentToTheScore;
        
                const int EASY_QUESTION_5 = 1;
                const int MEDIUM_QUESTION_10 = 2;
                const int HARD_QUESTION_15 = 3;
                const int GENERALPOINTS = 100;
        
                if (userAnswer == "A" || userAnswer == "B" || userAnswer == "C" || userAnswer == "D")
                {
                    if (answers == userAnswer)
                    {
                        if (questionNum <= EASY_QUESTION_5)
                        {
                            adjustmentToTheScore = (EASY_QUESTION_5 * GENERALPOINTS / totalTimePassed);
        
                            userScore += adjustmentToTheScore;
                        }
                        else if (questionNum <= MEDIUM_QUESTION_10)
                        {
                            adjustmentToTheScore = (MEDIUM_QUESTION_10 * GENERALPOINTS / totalTimePassed);
        
                            userScore += adjustmentToTheScore;
                        }
                        else if (questionNum <= HARD_QUESTION_15)
                        {
                            adjustmentToTheScore = (HARD_QUESTION_15 * GENERALPOINTS / totalTimePassed);
        
                            userScore += adjustmentToTheScore;
                        }
                        rightAnswerCount++;
        
                        goalSound.SoundLocation = "Goal_Sound.wav";
                        goalSound.Play();
        
                        lblTotalCorrect.Text = Convert.ToString(rightAnswerCount);
        
                        if (fastestAnswer == 0 || totalTimePassed < fastestAnswer)
                        {
                            fastestAnswer = totalTimePassed;
        
                            lblFastestAnswer.Text = Convert.ToString(fastestAnswer) + "(s)";
                        }
        
                   else
                        {
                            adjustmentToTheScore = 10;
        
                            userScore = userScore - adjustmentToTheScore;
        
                            booing.SoundLocation = "Booing.wav";
                            booing.Play();
                        }
        
                        lblScore.Text = "Score: " + Convert.ToString(userScore);
        
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid answer please put a, b, c or d!");
        
                        return false;
                    }
        
                }
                else  
                {
                return false; --- add for first if condition
                }
        }
