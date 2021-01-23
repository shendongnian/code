    class Program
    {
        public static float _playerChips = 1000;
        private static void Main()
        {            
            Console.Write("Player's Chips: ");
            Console.WriteLine(_playerChips);
            Console.Write("1. Play Slot  ");
            Console.WriteLine("2. Exit");
            choice(ref _playerChips);
            result(_playerChips);
            Console.ReadKey();
        }
        private static void choice(ref float playerChips)
        {
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                firstRandomNumberGenerator(ref playerChips);
            }
            if (choice == 2)
                Environment.Exit(0);
        }
        private static void betValidation(ref float playerChips, ref float bet)
        {                        
            Console.WriteLine("Enter your bet: ");
            bet = float.Parse(Console.ReadLine());
            if ((bet <= 0) || (bet > playerChips))
            {
                Console.WriteLine("You did not enter a valid bet.\n");
                Main();
            }
        }
        private static void firstRandomNumberGenerator(ref float playerChips)
        {
            float bet = 0;
            betValidation(ref playerChips, ref bet);
            System.Random r = new System.Random();
            int firstNumber = r.Next(2, 8);
            int secondNumber = r.Next(2, 8);
            int thirdNumber = r.Next(2, 8);
            if (firstNumber == secondNumber || firstNumber == thirdNumber || thirdNumber == secondNumber)
                playerChips = playerChips + (bet * 3);
            Console.Write(firstNumber);
            Console.Write(secondNumber);
            Console.Write(thirdNumber);
            Console.Write("\n");
        }
        private static void Update()
        {
            return;
        }
        private static void result(float playerChips)
        {
            return;
        }
    }
