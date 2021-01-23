    Console.Write("Color To Bet on: ");
    string tempColor = Console.ReadLine();
    
    while (String.IsNullOrWhiteSpace(tempColor))
    {
        Console.Write("The color can't be null.");
        tempColor = Console.ReadLine().ToLower();
    }
