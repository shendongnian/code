    Random roll = new Random();
    while(true)
    {
        // Request dice type from user
        Console.WriteLine("Please input the type of dice you want to roll. ");
    
        // Display dice types to user
        Console.WriteLine("4) Four-sided");
        Console.WriteLine("6) Six-sided");
        Console.WriteLine("8) Eight-sided");
        Console.WriteLine("10) Ten-sided");
        Console.WriteLine("12) Twelve-sided");
        Console.WriteLine("20) Twenty-sided");
        Console.WriteLine("100) Percentage");
        Console.WriteLine(" ");
        Console.WriteLine("Type quit to exit ");
    
        // Take dice type from user
        Console.Write("Type of Dice: ");
        string input = Console.ReadLine();
        if(input == "quit")
           break;
    
        DiceType typeOfDice;
    
        // Try to parse the input and check if it could be an enum of the 
        // desidered type (Note user can also input "foursides" not just 4
        if (!Enum.TryParse<DiceType>(input, true, out typeOfDice) || 
            !Enum.IsDefined(typeof(DiceType), typeOfDice))
            Console.WriteLine("That is not an acceptable die type. Please try again.");
        else
        {
           ....
           switch (typeOfDice)
           {
               case DiceType.FourSides:
                   .....
                   break;
               case DiceType.SixSides:
                   .....
                   break;
    
               ....
            }
        }
    }
