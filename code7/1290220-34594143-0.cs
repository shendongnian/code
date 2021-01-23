    using System;
    
    namespace GuessMyNumber
    {
    	class Program
    {
        static void Main(string[] args)
        {
            // variables
            Random slumpat = new Random(); 
            int gameNumber = slumpat.Next(1, 20); 
            int number;
    
            bool play = true; 
    
            while (play)
            {
                Console.Write("\n\tGuess a number between 1 and 20: ");
                if (!Int32.TryParse(Console.ReadLine(), out number))
                {
                Console.WriteLine("This only works with numbers!");
                }
                else
                {
    	
    	            if (number < gameNumber)
    	            {
    	
    	                Console.WriteLine("\tThe number you entered " + number + " is too small, try again.");
    	            }
    	
    	            else if (number > gameNumber)
    	            {
    	                Console.WriteLine("\tThe number you entered " + number + " is too big, try again.");
    	            }
    	
    	            else if (number == gameNumber)
    	            {
    	                Console.WriteLine("\tYou guessed right!");
    	                play = false;
    	            }
                }
            }
    
        }
    }
    }
