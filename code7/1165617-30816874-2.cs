    public static long __Id = 0;
    private static void Main(string[] args)
    {
        var sw1 = new Stopwatch();
        var guid = Guid.NewGuid();
        sw1.Start();
        for (var i = 0; i < 10000000; i++)
        {
            guid = Guid.NewGuid();
        }
        sw1.Stop();
        Console.WriteLine(guid);
        Console.WriteLine(sw1.ElapsedTicks);
        var sw2 = new Stopwatch();
        long id = 0;
        sw2.Start();
        for (var i = 0; i < 10000000; i++)
        {
            id = Interlocked.Increment(ref __Id);
        }
        sw2.Stop();
        Console.WriteLine(id);
        Console.WriteLine(sw2.ElapsedTicks);
    }
