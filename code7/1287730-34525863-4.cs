    while(true)
    {
        Console.Write("Color To Bet on: ");
        string tempColor = Console.ReadLine().ToLower();
        if (String.IsNullOrWhiteSpace(tempColor))
        {
            Console.Write("The color can't be null.");
            continue;
        }
        break;
    }
