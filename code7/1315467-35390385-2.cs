    static void Main(string[] args)
    {
        if (ConfigurationManager.ConnectionStrings["Default"] == null)
        {
            Console.WriteLine("Missing connection string configuration");
            Console.ReadKey();
            return;
        }
            
        string testConnectiongString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        Console.WriteLine("Doing work...");
        Console.ReadKey();
    }
