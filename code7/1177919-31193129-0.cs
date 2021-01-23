    while (iterations < 1000)
    {
        iterations++;
        Console.WriteLine("Enter value between 300 to 850.");
        string input = Console.ReadLine();
        int value;
        if (int.TryParse(input, out value))
        {
            if( input < 850 && input > 300 )
            {
                total +=input;
            }
        }
        else
        {
             break;  
        }
    }
