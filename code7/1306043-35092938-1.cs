    while (guess != computer)
    {
        guess = (end - start) / 2 + start;
        if (guess != computer)
        {
            if (guess > computer)
            {
                end = guess;
                Console.WriteLine("Your guess is too high, next guess: {0}", guess);
            }
            else
            {
                start = guess;
                Console.WriteLine("Your guess is too low, guess again: {0}", guess);
            }
            count = count + 1;
            Console.WriteLine("Count {0}", count);
        }
    }
    
