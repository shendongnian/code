        public static void RandomNumberGenerator()
        {
            Random rand = new Random();
    
            int randValue = rand.Next(1, 11);
            int attempts = 0;
    
            
            while (true)
            {
                int userValue = int.Parse(Console.ReadLine()); // input inside the loop
                if (userValue == randValue) // checking inside the loop
                {
                    Console.WriteLine("You have guessed correctly!");
                    break;
                }
                Console.WriteLine("You have guessed incorrectly");
                attempts++;
                Console.WriteLine("You have made {0} incorrect guesses",            attempts);                
            }
    
        }
