    public static void Main(string[] args)
    {
        Console.WriteLine("Type 'Help' to see list of commands");
        var input = Console.ReadLine();
        ParseInput(input); // call the function to process your input
    }
    private static void ParseInput(string input)
    {
        if (input.Contains("help") || input == "?")
        {
            Console.WriteLine("Available commands");
            Console.WriteLine("====================================");
            Console.WriteLine("Stats - Display player information");
            Console.ReadLine();
        }
        else if (input == "stats")
        {
            Console.WriteLine("Current hit points:");
            Console.ReadLine();
        }
    }
