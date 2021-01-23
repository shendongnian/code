    // Your player class. I've added 'id' so we can identify them by this later.
    class Player
    {
        public int id;
        public string name;
        public int rating;
    }
    // The dictionary. They work like this dictionary<key, value> where key is a unique identifier used to access the stored value. 
    // Useful since you wanted array type accessibility
    // So in our case int represents the player ID, the value is the player themselves
    Dictionary<int, Player> players = new Dictionary<int, Player>();
    // Create your players
    for (int i = 0; i < numberOfPlayers; i++)
    {
        Player p = new Player()
        {
            id = i + 1,
            name = $"Player{i}",
            rating = 5
        };
        // Add them to dictionary
        players.Add(p.id, p);
    }
    // Now you can access them by the ID:
    if (players.ContainsKey(1))
	{
        Console.WriteLine(players[1].name);
	}
