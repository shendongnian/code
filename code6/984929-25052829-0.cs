    static void Main(string[] args)
    {
        Console.CancelKeyPress += (sender, e) =>
            {
                Environment.Exit(0);
            };
    
        while (true)
        {
            // Do Stuff.
        }
    }
