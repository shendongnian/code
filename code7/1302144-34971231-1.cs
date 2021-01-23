        Random random = new Random();
        Console.Write("Num: ");
        for (Counter = 0; Counter < Number.Length; Counter++)
        {
            int Rep = random.Next(0, 345);
            Number[Counter] = Rep;
            Console.Write("{0} ", Rep);
        }
        Console.WriteLine();
