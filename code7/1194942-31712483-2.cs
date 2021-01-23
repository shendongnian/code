    namespace PracticeCSharp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Player test = new Player();
                test.Score = 5;
                Console.ReadLine();
            }
        
        }
        class Player
        {
            public int Score { get; set; }
        }
    }
