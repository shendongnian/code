    Console.Write("Color To Bet on: ");
    string tempColor = Console.ReadLine();
    
    while (String.IsNullOrWhiteSpace(tempColor))
    {
        Console.Write("The color can't be null.");
        Console.Write("Color To Bet on: ");
        tempColor = Console.ReadLine().ToLower();
    }
