    string sentinalValue = "done";
    string input = "";
    while (iterations < 1000 && input != sentinalValue)
    {
        iterations++;
        Console.WriteLine("Enter value between 300 to 850.");
        input = Console.ReadLine();
        int value;
        if (int.TryParse(input, out value))
        {
            if( value < 850 && value > 300 )
            {
                total +=input;
            }
        }
        else
        {
             Console.WriteLine("That is not a number!");
        }
    }
