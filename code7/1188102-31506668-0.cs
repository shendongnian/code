    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************** Let's play Master-Mind **************\n");
            string name = GetPlayerName();
            do
            {
                int numberCount = GetRandomNumberCount();
                Console.Write(numberCount + " it is. Let's play.");
                Console.WriteLine();
                int[] PCArray = GenerateRandomNumbers(numberCount);
                Console.WriteLine("A {0}-digit number has been chosen. Each possible digit may be the number 1 to 4.\n", numberCount);
                int difficulty = GetGameDifficulty();
                int allowedAttempts = difficulty * numberCount;
                int remaining;
                for (remaining = allowedAttempts; remaining > 0; remaining--)
                {
                    Console.WriteLine("\nEnter your guess ({0} guesses remaining)", remaining);
                    int[] userArray = GetUserGuess(numberCount);
                    int hits = CountHits(PCArray, userArray);
                    if (hits == numberCount)
                    {
                        Console.WriteLine("You win, {0}!", name);
                        Console.Write("The correct number is: ");
                        for (int j = 0; j < numberCount; j++)
                        {
                            Console.Write(PCArray[j] + " ");
                        }
                        break;
                    }
                }
                if (remaining == 0)
                {
                    Console.WriteLine("Oh no, {0}! You couldn't guess the right number.", name);
                    Console.Write("The correct number is: ");
                    for (int j = 0; j < PCArray.Length; j++)
                    {
                        Console.Write(PCArray[j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.Write("\nWould you like to play again (Y/N)? ");
            }
            while (Console.ReadLine().ToUpper() == "Y");
        }
        private static string GetPlayerName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome, {0}. Have fun!!\n", name);
            return name;
        }
        public static int GetRandomNumberCount()
        {
            int number;
            Console.Write("How many numbers would you like to use in playing the game (4-10)? ");
            while (!int.TryParse(Console.ReadLine(), out number) || number < 4 || number > 10)
                Console.WriteLine("You must pick a number between 4 and 10. Choose again.");
            return number;
        }
        public static int GetGameDifficulty()
        {
            int difficulty = 0;
            Console.Write("Choose a difficulty level (1=hard, 2=medium, 3=easy): ");
            while (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty < 1 || difficulty > 3)
                Console.WriteLine("Incorrect entry: Please re-enter.");
            return difficulty;
        }
        public static int[] GenerateRandomNumbers(int PCSize)
        {
            int eachNumber;
            int[] randomNumber = new int[PCSize];
            Random rnd = new Random();
            Console.Write("PC number: ");
            for (int i = 0; i < PCSize; i++)
            {
                eachNumber = rnd.Next(1, 5);
                randomNumber[i] = eachNumber;
                Console.Write(eachNumber);
            }
            Console.WriteLine();
            return randomNumber;
        }
        public static int[] GetUserGuess(int userSize)
        {
            int number = 0;
            int[] userGuess = new int[userSize];
            for (int i = 0; i < userSize; i++)
            {
                Console.Write("Digit {0}: ", (i + 1));
                while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 4)
                    Console.WriteLine("Invalid number!");
                userGuess[i] = number;
            }
            Console.WriteLine();
            Console.Write("Your guess: ");
            for (int i = 0; i < userGuess.Length; i++)
            {
                Console.Write(userGuess[i] + " ");
            }
            Console.WriteLine();
            return userGuess;
        }
        
        public static int CountHits(int[] PCArray, int[] userArray)
        {
            int hits = 0;
            for (int i = 0; i < PCArray.Length; i++)
            {
                if (PCArray[i] == userArray[i])
                    hits++;
            }
            Console.WriteLine("Results: {0} Hit(s), {1} Miss(es)", hits, PCArray.Length - hits);
            return hits;
        }
    }
