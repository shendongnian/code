    static void Main(string[] args)
        {
            Dictionary<string, string[]> skins = new Dictionary<string, string[]>();
            skins.Add("ahri", new string[] { "Academy", "Challenger", "Dynasty", "Foxfire", "Midnight", "Popstar" });
            skins.Add("leesin", new string[] { "Traditional", "Acolyte", "Dragon Fist", "Musy Thai", "Pool Party", "SKT T1", "Knockout" });
            // Creates title for application
            Console.WriteLine("Conor's Random League of Legends Skin Selector v0.1\r\n\r\n");
            Random rnd = new Random();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("What champion would you like to select a skin for?..    ");
            string champion = Console.ReadLine().ToLower();
            Console.Write("Press the 'enter' key for a random champion..     ");
            Console.ReadLine();
            if(skins.ContainsKey(champion))
            {
                //return a random champion skin from the user input key in dict based on a random number from the length of the string array
                Console.WriteLine(skins[champion][rnd.Next(skins[champion].Length)]);
            }
            
        }
