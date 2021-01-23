        static void Main(string[] args)
        {
            doSomething();
        }
        public static void WouldYouLikeToRestart()
        {
            Console.WriteLine("Press r to restart");
            ConsoleKeyInfo input = Console.ReadKey();
            Console.WriteLine();
            if (input.KeyChar == 'r')
            {
                doSomething();
            }
        }
        public static void doSomething()
        {
            Console.WriteLine("Do Something");
            WouldYouLikeToRestart();
        }
