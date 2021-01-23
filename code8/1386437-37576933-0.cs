    void Caller()
    {
        int result;
        if (TryDoSomething(out result, 100)) {
            System.Console.WriteLine("Result: {0}", result);
        }
    }
    bool TryDoSomething(out int result, int timeoutMillis)
    {
        var sw = Stopwatch.StartNew();
        result = 0x12345678;
        for (int i = 0; i != 100000000; ++i) {
            if (sw.ElapsedMilliseconds > timeoutMillis)
                return false;
            result += i / (result % 43) + (i % 19);
        }
        return true;
    }
