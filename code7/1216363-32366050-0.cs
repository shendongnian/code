        static void Main(string[] args)
        {
            string consoleInput;
            ShowOptions();         
         
            do
            {
                consoleInput = Console.ReadLine();
                if (consoleInput == "10")
                    Environment.Exit(0);
                DoSomething();
                ShowOptions();
            } while (consoleInput != null && consoleInput != "10");
        }
        private static void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine("What file would you like to test?");
            Console.WriteLine("1. Royal Flush");
            Console.WriteLine("2. Straight Flush");
            Console.WriteLine("3. Four of a Kind");
            Console.WriteLine("4. Full House");
            Console.WriteLine("5. Flush");
            Console.WriteLine("6. Straight");
            Console.WriteLine("7. Three of a Kind");
            Console.WriteLine("8. Two Pair");
            Console.WriteLine("9. Pair");
            Console.WriteLine("10. Exit");
        }
        private static void DoSomething() { Console.WriteLine("I am doing something!"); }
