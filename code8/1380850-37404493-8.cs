    List<ComputerGame> games = new List<ComputerGame>();
    games.Add(new ComputerGame("Age of Empires", 49.99));
    games.Add(new ComputerGame("Heroes and Generals", 30.00));
    games.Add(new ComputerGame("Team Fortress 2", 19.50));
    games.Add(new ComputerGame("Portal", 19.50));
    games.Add(new ComputerGame("Portal 2", 29.50));
    
    foreach(ComputerGame game in games)
    {
    	if (game != null)
    		Console.WriteLine($"Title: {game.title}, Price: {game.price}");
    }
    
    double total = games.Sum(p => p.price);
