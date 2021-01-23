    public static void Test1(bool warmup)
    {
        Point a = new Point(1, 1), b = new Point(1, 1);
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < ITERATIONS; i++)
            a = AddByVal(a, b);
        sw.Stop();
        Console.WriteLine("Result: x={0} y={1}, Time elapsed: {2} ms",
            0, 0, sw.ElapsedMilliseconds);
    }
