    while(true)
    {
        Console.Write("The first number=   ");
        int x;
        bool success = int.TryParse(Console.ReadLine(), out x);
    
        if (success)
            break;
    }
