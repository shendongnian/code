    Random random = new Random();
            while (true)
            {
                int randomNumber = random.Next(1, 5);
                int counter = 1;
                bool retry = true;
                while (true)
                {
                    Console.Write("Guess a number between 1 and 5");
                    int input = Convert.ToInt32(Console.ReadLine());
    
                    if (input < randomNumber)
                    {
                        Console.WriteLine("Too low, try again.");
                        ++counter;
                        continue;
                    }
                    else if (input > randomNumber)
                    {
                        Console.WriteLine("Too high, try again.");
                        ++counter;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Congratulations. You guessed the number!");
                        Console.WriteLine("Would you like to retry? y/n");
                        string answer = Console.ReadLine();
                        if (answer != "y")
                        {
                            retry = false;
                            break;
                        }
                        break;
                    }
    
                }
                if (!retry) break;
    
            }
