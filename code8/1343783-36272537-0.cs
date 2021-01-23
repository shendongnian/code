    static int Main(string[] args)
    {
        // Test if argument was supplied:
        if (args.Any(a => a == "/keepopen"))
        {
            System.Console.ReadLine();
        }
    }
