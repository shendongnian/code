    string input = "|2P|1|U|F8|";
    
    foreach (string item in input.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
    {
        Console.WriteLine(item);
    }
