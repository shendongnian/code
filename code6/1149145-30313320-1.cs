    public static void Main()
    {
        const int iterations = 10000;
        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < iterations; i++)
        {
            var z = EquasionOne(1, 2, 3);
        }
        sw.Stop();
        Console.WriteLine("Equation one took: {0} ticks", sw.ElapsedTicks);
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            var z = EquasionTwo(1, 2, 3, 4);
        }
        sw.Stop();
        Console.WriteLine("Equation two took: {0} ticks", sw.ElapsedTicks);
    }
