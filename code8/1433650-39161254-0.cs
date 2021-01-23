    public static void DisplayText(string Default)
    {
        //I have simplified the method but you get the point
        Console.WriteLine(Default);
    }
    class Player
    {
        public string name { get; set; }
        public string class { get; set; }
    }
    public static void Main()
    {
        Player player = new Player();
        player.name = "uTeisT";
        player.class = "Novice";
        DisplayText($"Welcome to you, {player.name} the {player.class}.");
    }
