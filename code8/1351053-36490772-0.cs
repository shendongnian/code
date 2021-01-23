    private bool CheckIfCorrect(byte questionNum, string answers, string userAnswer)
        {
           //init here
            if (userAnswer == "A" || userAnswer == "B" || userAnswer == "C" || userAnswer == "D")
            {
                if (answers == userAnswer)
                {
                    if (questionNum <= EASY_QUESTION_5)
                    {
                        //Some code
                    }
                    else if (questionNum <= MEDIUM_QUESTION_10)
                    {
                        //Some code
                    }
                    else if (questionNum <= HARD_QUESTION_15)
                    {
                        //Some code
                    }
                    if (true)
                    {
                        //Some code
                    }
                    else
                    {
                        //Some code
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
      }  
            
