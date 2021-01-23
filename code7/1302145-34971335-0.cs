    int[] Number = new int[15];    
    int Counter;
    Random random = new Random();
    for (Counter=0; Counter<Number.Length; Counter++)
    {
        int Rep = 0;
        Rep = random.Next(0, 345);
        Number[Counter] = Rep;
    }
    Console.WriteLine(String.Join(",", Number));
