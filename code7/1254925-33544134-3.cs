    Console.Write("High priority? input yes or no: ");
    string important = Console.ReadLine();
    if (important.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Priority: Important");        
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Priority: Normal");
    }
    Console.ResetColor(); //default
