    public class GuessingGame
    {
        int guessesLeft = 0;
        int gamesPlayed = 0;
        int gamesWon = 0;
        int gamesLost = 0;
        int myGuess = 0;
        
        Random rand = new Random();
        int number = rand.Next(1, 100);
        public int Guess
        {
            get
            {
                return myGuess;
            }
            set
            {
                myGuess = value;
            }
        }
        // Reset game method. You can call it from form too.
        public void ResetGame()
        {
            number = rand.Next(1, 100);
            guessesLeft = 0;
        }
        public void checkGuess(int newGuess)
        {
            myGuess = newGuess;
            if (guessesLeft > 10)
            {
                Console.WriteLine("you lose!");
                gamesLost++;
                gamesPlayed++;
                ResetGame();
            }
            else if (myGuess > number)
            {
                Console.WriteLine("your guess is too high, try again.");
                guessesLeft++;
            }
            else if (myGuess < number)
            {
                Console.WriteLine("your guess is too low, try again.");
                guessesLeft++;
            }
            else
            {
                Console.WriteLine("you win!");
                gamesPlayed++;
                gamesWon++;
                ResetGame();
            }
        }
    }
