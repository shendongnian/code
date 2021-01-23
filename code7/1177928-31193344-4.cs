    Console.WriteLine("Enter value between 300 to 850.");
    input = Console.ReadLine();
    int value = 0;
    if (int.TryParse(input, out value))
    {
        // Clearly it's a valid integer at this point
        if (value < 850 && value > 300)
        {
            total += value;
        }
    }
    else
    {
        // Wasn't a number, might be our sentinel.
        if (input == "calculate")
            break;  
        else
        {
            // Throw an error or something.
        }
    }
