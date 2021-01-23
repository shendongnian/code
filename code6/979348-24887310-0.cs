    while (true)
    {
        Console.Write("Enter the number of victims so we can predict the next murder, Sherlock: ");
        victimCount = int.Parse(Console.ReadLine());
        if (victimCount == 1)
        {
            Console.Write("that's an invalid number.");
        }
        else
        {
            break;
        }
    }
