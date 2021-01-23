    public void Username()
    {
        PlayerStats pStats = new PlayerStats();
        string name;
        Header();
        Console.Write("\nChoose your USERNAME: ");
        name = Console.ReadLine();
        pStats.pName = name;
    }
