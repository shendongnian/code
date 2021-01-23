    int axisx = 0;
    int axisy = 0;
    while (true)
    {
        var movement = Console.ReadKey();
        if (movement.KeyChar == 'W')
        {
            axisy = axisy + 1;
        }
        else if (movement.KeyChar == 'S')
        {
            axisy = axisy - 1;
        }
        else if (movement.KeyChar == 'D')
        {
            axisx = axisx + 1;
        }
        else if (movement.KeyChar == 'A')
        {
            axisx = axisx - 1;
        }
        Console.WriteLine("{2} is on position:{0},{1}", axisx, axisy, Player1.getBuilderName());
        if (movement.Key == ConsoleKey.Escape)
        {
            Console.WriteLine("You pressed Escape, Goodbye");
            break;
        }
    }
