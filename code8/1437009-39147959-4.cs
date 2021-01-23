    public string Username()
    {
        Header();
        Console.Write("\nChoose your USERNAME: ");
        name = Console.ReadLine();
        return name;
    }
    
    public void Welcome(PlayerStats pStats)
    {
        Header();
        Console.WriteLine("Hello!");
        Console.WriteLine(pStats.pName);
    }
    
    static void Main(string[] args)
    {
        PlayerStats pStats = new PlayerStats();
        
        Jobs jobCl = new Jobs();
        GUI gui = new GUI();
        gui.Header();
        gui.StartPage();
        pStats.pName = gui.Username();
        gui.ChoosepJob();
        gui.Welcome(pStats);
        Console.ReadLine();
    }
