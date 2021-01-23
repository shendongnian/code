    public static void Main(string[] args)
    {
        Player player = new Player();
        player.health = 20;
        method2(player);
    }
    
    public static void method2(Player player)
    {
        //Here I want to access the "player" in the Main method.
    
        //Then I want to print this and other stats to a text document:
        string[] lines = { player.Health, "Stat 1", "Stat 2", "Stat 3" };
    
        System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
    
        Process.Start(@"C:\Users\Public\TestFolder\WriteLines.txt");
    }
