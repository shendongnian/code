    var test = new MovingAverage(11);
    for (int i = 0; i < 25; ++i)
    {
        test.Add(i);
        Console.WriteLine(test.Average);
    }
