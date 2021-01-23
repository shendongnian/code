    for (int i = 1; i < 256; i++)
    {
        Console.WriteLine(i + " = " + (char)i);
        if (i % 22 == 0)
        {
            Console.WriteLine("Please press any key to turn page");
            Console.ReadKey();
            Console.Clear();
        }
    }
