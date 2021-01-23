    public static void DisplayText(string Default)
    {
        //I have simplified the method but you get the point
        Console.WriteLine(Default);
    }
    class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
    public static void Main()
    {
        Player player = new Player();
        player.Name = "uTeisT";
        player.Class = "Novice";
        //Passing the parameter with new feature
        //Results in more readable code and ofc no change in current method
        DisplayText($"Welcome to you, {player.Name} the {player.Class}.");
    }
