        Random random = new Random();
        for (Counter = 0; Counter < Number.Length; Counter++)
        {
            int Rep = random.Next(0, 345);
            Number[Counter] = Rep;
            Console.Write("{0} ", Rep);
        }
        Console.WriteLine();
