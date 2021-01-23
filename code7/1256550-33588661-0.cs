    static void Main(string[] args)
    {
        Random RandomGenerator = new Random();// random number generator
               
        while (true)
        {
            Console.WriteLine("i have thought of a number between 1 and 100");//display message
            bool guessedCorrect = false;
            int IN_RandomNum = RandomGenerator.Next(1, 100); //the range
                                                                //loop 10 times 
            for (int i = 0; i < 10; i++) //for loop created
            {
                int IN_Guess; //guessing integer
                Console.Write("{0} turns left, enter your next guess>", 10 - i);//number of turns players has 
                                                                                //
                IN_Guess = Convert.ToInt32(Console.ReadLine()); //string to number
                                                                //Now check if guess is same as generated 
                if (IN_Guess == IN_RandomNum)//if guess is equal to generated number
                {
                    Console.WriteLine("correct in {0} turns", i + 1); //if guessed correctly 
                    guessedCorrect = true;
                    break; //breaking code
                }
                else if (IN_Guess > IN_RandomNum) //if guess is higher than generated number
                {
                    Console.WriteLine("Too high");// if guessed number is too high
                }
                else //then...
                {
                    Console.WriteLine("Too low"); // if guessed number is too low
                }
                if (i == 8) //on last turn display this message
                {
                    Console.WriteLine("*YOU ONLY HAVE 1 GUESS LEFT!*"); //display this message 
                }
            }
    
            if (guessedCorrect)
            {
                Console.WriteLine("Good job... Lets try again");
            }
            else
            {
                Console.WriteLine("Better luck next timer... here we go");
            }
        }
    }
