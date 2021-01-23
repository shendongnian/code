    static void Main(string[] args)
    {
        Console.Clear(); //For a 'clean slate' on every execution, can ditch this if you want
        Console.ForegroundColor = ConsoleColor.Gray;
    
        Dictionary<string, string[]> skins = new Dictionary<string, string[]>();
        skins.Add("ahri", new string[] { "Academy", "Challenger", "Dynasty", "Foxfire", "Midnight", "Popstar" });
        skins.Add("leesin", new string[] { "Traditional", "Acolyte", "Dragon Fist", "Musy Thai", "Pool Party", "SKT T1", "Knockout" });
    
        Console.WriteLine("Conor's Random League of Legends Skin Selector v0.1\r\n\r\n");
        Console.WriteLine("What champion would you like to select a skin for? \r\nPress enter for a random champion...    ");
                
        var champion = Console.ReadLine(); 
        var rnd = new Random();
        if (champion.Equals(string.Empty))
        {
            var tmpList = Enumerable.ToList(skins.Keys);
            champion = tmpList[rnd.Next(tmpList.Count)];
        }
        else
        {
            champion = champion.Trim().ToLower(); 
        }
    
        Console.Write(string.Format("Champion {0} Selected \r\n", champion));
                
        if (skins.ContainsKey(champion)) 
        {
            Console.WriteLine(string.Format("Your random skin for {0} is: {1}\r\n", champion, skins[champion][rnd.Next(skins[champion].Length)]));
        }
        else
        {
            Console.Clear(); //clear the slate so console doesn't look cluttered.
            Main(args); 
        }
    }
