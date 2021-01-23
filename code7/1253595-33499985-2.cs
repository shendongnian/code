    while (loopie)
    {
        Console.Write("Number one: ");
        if (!Int32.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Wrong input. try again.");
            continue;
        }
        Console.WriteLine(" ");
        Console.Write("Number two: ");
        if (!Int32.TryParse(Console.ReadLine(), out result2))
        {
            Console.WriteLine("Wrong input. try again.");
            continue;
        }
        Console.WriteLine(" ");
        Console.Write("Number two: ");
        if (!Int32.TryParse(Console.ReadLine(), out result3))
        {
            Console.WriteLine("Wrong input. try again.");
            continue;
        }
        Console.WriteLine(" ");
        int summa = result + result2 + result3;
        Console.WriteLine("summan: " + summa);
    }
