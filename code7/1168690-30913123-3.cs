    for (int i = 0; i < numbers; i++)
    {
        Console.Write("What is the {0}. number? ", i + 1);
        double? num = ReadNumberFromConsole();
        if (num.HasValue)
        {
            allNumbers[i] = num.Value;
        }
        else
        {
            i--; // ask the user until we have the numbers
            Console.Beep();
            Console.WriteLine("");
            Console.WriteLine("You have entered an invalid number!");
            Console.WriteLine("");
        }
    }
