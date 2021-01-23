    string[] allowedInput = new String[]{"black", "greed", "red"};
    Console.Write("Color To Bet on: ");
    string tempColor = Console.ReadLine();
    
    while ((String.IsNullOrWhiteSpace(tempColor)) || (!allowedInput.Contains(tempColor)))
    {
        Console.Write("The color can't be null.");
        tempColor = Console.ReadLine().ToLower();
    }
