    ConsoleKeyInfo cki;
    cki = Console.ReadKey();
    if (cki.Key == ConsoleKey.Y)
    {
        Console.Clear();
    }
    else if (cki.Key == Console.N)
    {
        Console.Clear();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Enter letters only");
    }
