     namespace TestCoin2
    {
    class Program
    {
        public enum CoinSides { Heads = 0, Tails = 1 }
        static void Main(string[] args)
        {
            string userInput;// This will hold all my user input/ answers.
            Console.WriteLine("Hello, Pick Heads or Tails:");
            userInput = Console.ReadLine();
            int coin;// this will hold my random int numbers.
            Random rng = new Random();
            coin = rng.Next(0, 2);
            if (coin == Convert.ToInt32(CoinSides.Heads) && userInput == CoinSides.Heads.ToString("D"))
            {
                Console.WriteLine("You picked Right! Heads! YOU WIN!");
            }
            else if (coin == Convert.ToInt32(CoinSides.Tails) && userInput == CoinSides.Tails.ToString("D"))
            {
                Console.WriteLine("You picked Right! Tails! YOU WIN!");
            }
            else
            {
                Console.WriteLine("You picked Wrong! it was..." + myString);
            }
            Console.ReadLine();
        }
    }
    }
