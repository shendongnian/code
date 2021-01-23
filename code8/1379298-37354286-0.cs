       public static void Main(string[] args)
        {
            var KP = Console.ReadKey();
            if (KP.Key == ConsoleKey.F2)
            {
                return;               
            }
            string UserName = KP.KeyChar + Console.ReadLine();
            Console.WriteLine(UserName);
            Console.ReadLine();
        }
