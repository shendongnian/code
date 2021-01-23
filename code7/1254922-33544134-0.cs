    Console.Write("High priority? input yes or no: ");
    string important = Console.ReadLine();
    if (important.Equals("yes", StringComparison.InvariantCultureIgnoreCase)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Priority: Important");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
        Console.Write("Priority: Normal");
