    for (int x0 = 0; x0 < schedule.GetLength(0); x0++)
    {
        for (int x1 = 0; x1 < schedule.GetLength(1); x1++)
        {
            Console.Write("{0}\t", schedule[x0, x1]);
        }
        Console.WriteLine();
    }
    Console.ReadKey();
