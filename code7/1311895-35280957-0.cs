    class Program
    {
        static void Main(string[] args)
        {
            string[] ahri = { "Academy", "Challenger", "Dynasty", "Foxfire", "Midnight", "Popstar" };
            string[] leeSin = { "Traditional", "Acolyte", "Dragon Fist", "Musy Thai", "Pool Party", "SKT T1", "Knockout" };
            // Creates title for application
            Console.WriteLine("Conor's Random League of Legends Skin Selector v0.1");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Random rnd = new Random();
            Console.ForegroundColor = ConsoleColor.Gray;
            // Stores what array has been selected:
            string[] champions;
            Console.WriteLine("What champion would you like to select a skin for?..    ");
            string championName = Console.ReadLine();
            if (championName.Equals("ahri", StringComparison.CurrentCultureIgnoreCase))
            {
                champions = ahri;
            }
            else if (championName.Equals("leeSin", StringComparison.CurrentCultureIgnoreCase))
            {
                champions = leeSin;
            }
            else 
            {
                // No champion selected, exit program:
                Console.WriteLine("No champion selected, quitting...");
                return;
            }
            while (true)
            {
                // Gets user to press a key to run the code
                Console.WriteLine("Press the 'enter' key for a random champion..     ");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {                    
                    int randomNumber = rnd.Next(champions.Length);
                    Console.WriteLine(champions[randomNumber]);
                }
            }
        }
    }
