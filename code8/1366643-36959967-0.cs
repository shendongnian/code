    public static void RandomNumberGenerator()
    {
        Random rand = new Random();
    
        int randValue = rand.Next(1, 11);
        int attempts = 0;
    
        do
        {
            int userValue = int.Parse(Console.ReadLine());
            
            if (userValue == randValue)
            {
                Console.WriteLine("You have guessed correctly!");
                break;
            }
            Console.WriteLine("You have guessed incorrectly");
            attempts++;
            Console.WriteLine("You have made {0} incorrect guesses", attempts);
        }
        while(userValue != randValue)
    }
