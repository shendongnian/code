    static void Main(string[] args)
    {
        PlayerStats pStats = new PlayerStats();
        Jobs jobCl = new Jobs();
        GUI gui = new GUI();
        gui.Header();
        gui.StartPage();
        gui.Username(pStats);
        gui.ChoosepJob(jobCl);
        gui.Welcome(pStats);
        Console.ReadLine();
    }
    public void Welcome(PlayerStats pStats)
    {
        Header();
        Console.WriteLine("Hello!");
        Console.WriteLine(pStats.pName);
    }
    public void Username(PlayerStats pStats)
    {
        string name;
        Header();
        Console.Write("\nChoose your USERNAME: ");
        name = Console.ReadLine();
        pStats.pName = name;
    }
