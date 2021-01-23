    Random rnd = new Random();
    int comp = rnd.Next(10);
    int guess;
    int numberofGuesses = 3;
    int counter = 0;
            Console.WriteLine("guess a number 0-10");
            do
            {
                guess = int.Parse(Console.ReadLine());
                if (guess == comp)
                {
                    Console.WriteLine("congratz!! u won!!");
                    Console.WriteLine("press any key to exit");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    if (guess > comp)
                    {
                        Console.WriteLine("your guess is greater than my number, yow!");
                    }
                    else
                    {
                        Console.WriteLine("your guess is lower than my number, yow!");
                    }
                    if(counter!=numberofGuesses - 1)
                        Console.WriteLine("Guess again!");
                    counter++;
                }
            } while (counter < numberofGuesses);
            Console.WriteLine("loser!!" + "My number was:" + comp);
            Console.ReadKey();
            return;
        }
