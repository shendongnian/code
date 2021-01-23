    using System;
    namespace StackOverflow
    {
        class Program
        {
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);
            static void Main(string[] args)
            {
                int maxGuesses = 5; //putting this in a variable allows you to amend the difficulty
                new Program(maxGuesses);
                Console.WriteLine("Done; press enter to end");
                Console.ReadLine();
            }
            //Kicks off the game
            //On completion asks if the user wants to play again
            //If so relaunches the game; if not exits.
            Program(int maxGuesses)
            {
                bool playAgain = true;
                while (playAgain)
                {
                    Play(maxGuesses);
                    playAgain = PromptToPlayAgain();
                }
            }
            //returns: 
            //- true if user enters Y
            //- false if user enters N
            //if user enters anything else, keeps asking
            bool PromptToPlayAgain() 
            {
                String againResponse = "";
                while (againResponse != "y" && againResponse != "n")
                {
                    Console.WriteLine("Would you like to play again? (Y/N)");
                    againResponse = Console.ReadLine().Trim().ToLower();
                }
                return againResponse == "y";
            }
            double GetVelocity()
            {
                Console.Write("Enter the initial velocity of the cannonball: ");
                return double.Parse(Console.ReadLine());
            }
            double GetAngle()
            {
                Console.Write("Enter the angle of the cannon (between 0 and 90 degrees): ");
                return double.Parse(Console.ReadLine());
            }
            //generate a random distance
            //returns a double where 100 <= d < 300
            double GetRangeDistance()
            {
                return randomNumberGenerator.Next(1000, 3000)/10; //returns
            }
            //return true if the person's within .5 meters of the target; else false
            bool CheckWinCondition(double targetDistance)
            {
                return targetDistance <= 0.5 && targetDistance >= -0.5;
            }
            //display message if successful
            void ReportHit()
            {
                Console.WriteLine();
                Console.WriteLine("Hit! Congratulations! You hit the target!");
            }
            //display message if missed
            void ReportMiss(double shotDistance, double targetDistance)
            {
                Console.WriteLine("Miss! Your shot hit {0} meters. The target is {1} meters away.", shotDistance, targetDistance); //use {n} string formatting to put your numbers into your string
                Console.WriteLine(); //NB: the blank line's the other way round to how you have it in ReportHit
            }
            //the game
            void Play(int maxGuesses)
            {
                Golf golf = new Golf();
                double distance = GetRangeDistance();
                for (int guess = 1; guess <= maxGuesses; guess++) //use a for loop instead of while as we want to iterate a given number of times
                {
                    double userVelocity = GetVelocity();
                    double userAngle = GetAngle();
                    //since we're using different variables for targetDistance and distance I assume 
                    //that each shot's being taken from the tee; i.e. the player doesn't move to 
                    //where the ball lands.
                    //Also I assume all shots go in a straight line between the tee and the hole
                    //and that angle is just up/down; not left/right, as otherwise the calc for
                    //target distance is off.
                    double shotDistance = golf.Fire(userAngle, userVelocity); //store this in a variable so we can reuse the result without recalculating
                    double targetDistance = distance - shotDistance;
                    if (CheckWinCondition(targetDistance)) 
                    {
                        ReportHit();
                        break; //exits the for loop early
                    }
                    else
                    {
                        ReportMiss(targetDistance, shotDistance);
                    }
                }
            }
        }
    }
