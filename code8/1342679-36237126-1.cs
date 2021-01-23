    Dictionary<string, string> names = new Dictionary<string, string>
    {
        {"1", "John"},
        {"2", "Anna"},
        {"3", "Gary"},
        {"4", "Jacob"},
        {"5", "Jennifer"}
    };
    
    Console.WriteLine("What is your ID?");
    string userInput = Console.ReadLine();
    if (names.Keys.Contains(userInput))
    {
        Console.WriteLine("Hello " + names[userInput] + "! Nice to see you online.");
    }
    else
    {
        Console.WriteLine("Sorry, this is not a valid ID. Bye.");
    }
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
