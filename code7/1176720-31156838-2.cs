    int numTries = 3;
    Random rd = new Random();
    while (true)
    {
        Console.WriteLine("guess a number 0-10");
        int number = rd.Next(11); // 0-10
        for (int currentTry = 1; currentTry <= numTries; currentTry++)
        {
            int guess;
            if (!int.TryParse(Console.ReadLine().Trim(), out guess))
            {
                Console.WriteLine("Please enter a valid integer between 0 and 10!");
                continue;  // next try
            }
            if (guess == number)
            {
                Console.WriteLine("congratz!! u won!!");
                break;  // breaks for-loop
            }
            else if(currentTry == numTries)  // last try
                Console.WriteLine("loser!!" + "My number was: " + number);
            else if (guess < number)
                Console.WriteLine("your guess is lower than my number, yow!");
            else if (guess > number)
                Console.WriteLine("your guess is greater than my number, yow!");
        }
    }
