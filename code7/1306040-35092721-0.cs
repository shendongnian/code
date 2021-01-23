            static void Main(string[] args)
            {
                int start = 0;
                int end = 100;
                Random myRandom = new Random();
                int computer = myRandom.Next(start, end);
                int count = 0;
                int guess;
                
                while (true)
                {
                    guess = (end - start) / 2 + start;
                    count = count + 1;
                    Console.WriteLine("Count {0}", count);
                    if (guess > computer)
                    {
                        end = guess;
                        Console.WriteLine("Your guess is too high, next guess: {0}", guess); 
                    }
                    else if (guess < computer)
                    {
                        start = guess;
                        Console.WriteLine("Your guess is too low, guess again: {0}", guess);
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("You got it. The number is {0}. It took you {1} guesses.", computer, count);
                Console.ReadKey();
            }
