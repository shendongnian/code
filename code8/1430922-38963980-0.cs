    public void gameStart()
    {
    
        for (game = 1; game <= numPlays; game++)
        {
            Console.WriteLine("Please choose Rock, Paper, or Scissors");
            string userSelection = Console.ReadLine();
    
            Random r = new Random();
            int computerSelection = r.Next(4);
    
    
            if (computerSelection == 1)
            {
                if (userSelection == "rock")
                {
                    Console.WriteLine("Computer Choice: Rock\n");
                    Console.WriteLine("Game [{0}] is a tie", game);
                }
                else if (userSelection == "paper")
                {
                    Console.WriteLine("Computer Choice: Paper\n");
                    Console.WriteLine("Game[{ 0}] is a tie", game);
                }
                else if (userSelection == "scissors")
                {
                    Console.WriteLine("Computer Choice: Scissors\n");
                    Console.WriteLine("Game [{0}] is a tie", game);
                }
                else
                {
                    Console.WriteLine("You must choose either rock, paper or scissors");
                }
    
            }
    
            else if (computerSelection == 2)
            {
                if (userSelection == "rock")
                {
                    Console.WriteLine("Computer Choice: Paper\n");
                    Console.WriteLine("You lose game [{0}], papaer beats rock", game);
    
                }
                else if (userSelection == "paper")
                {
                    Console.WriteLine("Computer Choice: Scissors\n");
                    Console.WriteLine("You lose game [{0}], scissors beats paper", game);
    
                }
                else if (userSelection == "scissors")
                {
                    Console.WriteLine("Computer Choice: Rock\n");
                    Console.WriteLine("You lose game [{0}], Rock beats scissors", game);
                }
                else
                {
                    Console.WriteLine("You must choose either rock, paper or scissors");
                }
    
            }
    
    
            else if (computerSelection == 3)
            {
                if (userSelection == "rock")
                {
                    Console.WriteLine("The computer chose scissors");
                    Console.WriteLine("You win game [{0}], rock beats scissors", game);
    
                }
                else if (userSelection == "paper")
                {
                    Console.WriteLine("The computer chose rock");
                    Console.WriteLine("You win game [{0}],paper beats rock", game);
    
                }
                else if (userSelection == "scissors")
                {
                    Console.WriteLine("The computer chose paper");
                    Console.WriteLine("You win game [{0}], scissors beats paper!", game);
    
                }
                else
                {
                    Console.WriteLine("You must choose either rock, paper or scissors");
    
                }
    
                Console.ReadLine();
                //        int arrayIndex = game - 1;
                //        gameArray[arrayIndex].Result = game;
                //    }
    
    
                //    }
    
                //public override string ToString()
                //{
    
    
                //    string outputString = game + "\n";
    
                //    for (int game = 1; game < numPlays; game++)
                //    {
                //        int index = game - 1;
                //        outputString += "Game " + game + ":" + gameArray[index].Result + "\n";
                //    }
    
                //    return outputString;
                //}
    
    
            }
        }
    }
