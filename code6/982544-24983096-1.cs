    static void Main(string[] args)
    {
        Random r = new Random(0);
        string[] values = (from i in Enumerable.Range(1, 500)
                            let order = r.Next()
                            orderby order
                            select i.ToString(CultureInfo.InvariantCulture)
                                        + ". " + RandomString(r)).ToArray();
        string[] fpmValues = values.ToArray();
        string[] csexValues = values.ToArray();
        Benchmark("FPM ", () => Array.Sort(fpmValues,
            new Comparison<string>(CompareFpm)));
        Benchmark("CSEX", () => Array.Sort(csexValues,
            new Comparison<string>(CompareCSEx)));
        Console.WriteLine("Sort equal: {0}",
            Enumerable.SequenceEqual(fpmValues, csexValues));
    }
    static string RandomString(Random r)
    {
        int len = r.Next(1, 32);
        char[] buf = new char[len];
        for (int i = 0; i < len; ++i)
        {
            buf[i] = (char)r.Next('A', 'Z');
        }
        return new string(buf);
    }
    static int CompareFpm(string x, string y)
    {
        int xi, yi;
        var parts = x.Split('.');
        if(parts.Length == 0 || !int.TryParse(parts[0], out xi))
        {
            xi = int.MaxValue;
        }
        parts = y.Split('.');
        if (parts.Length == 0 || !int.TryParse(parts[0], out yi))
        {
            yi = int.MaxValue;
        }
        return xi - yi;
    }
    static void Benchmark(string name, Action a)
    {
        long start = Stopwatch.GetTimestamp(), end;
        long runs = 0;
        do
        {
            a();
            ++runs;
            end = Stopwatch.GetTimestamp();
        }
        while ((end - start) < (Stopwatch.Frequency * 5));
        Console.WriteLine("{0}: {1} runs/sec", name, runs / 5);
    }
