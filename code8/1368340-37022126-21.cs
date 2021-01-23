    public static void PropertiesGetterString()
    {
        int count = 100000;
        var bar = new Bar
        {
            Id = 42,
            Number = "42",
        };
        var props = bar.GetType().GetProperties();
        string concat1 = "";
        string concat2 = "";
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < count; i++)
        {
            concat1 += (string)props[1].GetValue(bar);
        }
        sw.Stop();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        long millisecondsReflection = sw.ElapsedMilliseconds;
        sw.Restart();
        for (int i = 0; i < count; i++)
        {
            concat2 += bar.Number;
        }
        sw.Stop();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        long milliseconds = sw.ElapsedMilliseconds;
        Console.WriteLine("Without reflection: " + milliseconds);
        Console.WriteLine("With reflection: " + millisecondsReflection);
        Console.WriteLine(concat1.Length + concat2.Length); // Try with and without this line commented out.
    }
