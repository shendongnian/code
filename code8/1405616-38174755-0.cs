    void StartingArea()
    {
        System.Console.WriteLine("You awake in a stupor. The sun blinds you as you roll over to breathe the new day.");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("To your (west), you see a volcanic mountain, with a scraggly, dangerous looking path.");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("In the (east), you see a thick forrest. there is nothing visible past the treeline.");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("Looking (south), you see a long winding road that seems to have no end.");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("Hearing a sound of celebration, you look to the (north). There appears to be a city, with a celebration going on.");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("  ");
        System.Console.WriteLine("Which direction would you like to travel?");
        string direction1 = Convert.ToString(Console.ReadLine());
    
        if (direction1 == "north" || direction1 == "North")
        {
            AlArtharGate();
        }
    }
    void AlArtharGate()
    {
        Console.WriteLine("You proceed towards the north, only to be stopped by a guard:");
        Console.WriteLine("Guard: 'the kingdom of al'arthar is off limits to outsiders today, its the queens birthday, and the kingdom is packed full");
        Console.WriteLine("  ");
        Console.WriteLine("  ");
        Console.WriteLine("you can either try to (swindle) the guard, or (leave). What will you do?");
        string guardConvo1 = Convert.ToString(Console.ReadLine());
        if (string.Equals(guardConvo1, "leave", StringComparison.CurrentCultureIgnoreCase))
        {
            StartingArea();
        }
    }
