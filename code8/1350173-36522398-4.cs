    public static void Test()
    {
        ISummer summer = new Summer();
        Stopwatch sw = Stopwatch.StartNew();
        int n = 0;
        for (int i = 0; i < 1000000000; ++i)
        {
            n = summer.Sum(n, i);
        }
        Console.WriteLine("Vtable call took {0} ms, result = {1}", sw.ElapsedMilliseconds, n);
        Summer summer2 = new Summer();
        sw = Stopwatch.StartNew();
        n = 0;
        for (int i = 0; i < 1000000000; ++i)
        {
            n = summer.Sum(n, i);
        }
        Console.WriteLine("Non-vtable call took {0} ms, result = {1}", sw.ElapsedMilliseconds, n);
        Func<int, int, int> sumdel = (a, b) => a + b;
        sw = Stopwatch.StartNew();
        n = 0;
        for (int i = 0; i < 1000000000; ++i)
        {
            n = sumdel(n, i);
        }
        Console.WriteLine("Delegate call took {0} ms, result = {1}", sw.ElapsedMilliseconds, n);
        sw = Stopwatch.StartNew();
        n = 0;
        for (int i = 0; i < 1000000000; ++i)
        {
            n = Sum(n, i);
        }
        Console.WriteLine("Static call took {0} ms, result = {1}", sw.ElapsedMilliseconds, n);
    }
