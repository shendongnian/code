    while(true)
    {
        Console.Write("Color To Bet on: ");
        string tempColor = Console.ReadLine().ToLower();
        if (String.IsNullOrWhiteSpace(tempColor))
        {
            Console.Write("The color can't be null.");
            continue;
        }
        if (tempColor != "black" && tempColor != "blue"  && tempColor != "red")
        {
            Console.Write("The color must be Black, Blue or Red");
            continue;
        }
        break;    
    }
