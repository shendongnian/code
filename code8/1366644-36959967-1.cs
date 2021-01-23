    public static void RandomNumberGenerator()
    {
        Random rand = new Random();
    
        int randValue = rand.Next(1, 11);
        int attempts = 0;
    
        // do...while cycle to ask user to enter new value each time the used has been wrong
        do
        {
            // read user input
            int userValue = int.Parse(Console.ReadLine());
            
            // if user guessed correct
            if (userValue == randValue)
            {
                Console.WriteLine("You have guessed correctly!");
                // go away from do...while loop
                // it will stop asking user and will exit from the method
                break;
            }
            // if user has been wrong
            Console.WriteLine("You have guessed incorrectly");
            // increment attempts count
            attempts++;
            Console.WriteLine("You have made {0} incorrect guesses", attempts);
        }
        // and repeat until user guessed correctly
        while(userValue != randValue)
    }
