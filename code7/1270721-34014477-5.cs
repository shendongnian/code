    public string nbuversion { get; set; } //readline into "Global" property here
    public void GetVersion()
    {
        Console.WriteLine("Enter the Version:"); // Prompt for version
        nbuversion = Console.ReadLine(); //remove "string"
    }
