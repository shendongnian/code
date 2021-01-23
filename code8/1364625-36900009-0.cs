    static void Main(string[] args)
    {
        ThreadPool.SetMinThreads(2500, 10);
        Stopwatch sw = Stopwatch.StartNew();
        RunTasksOutter(10);
        sw.Stop();
        Console.WriteLine($"Finished in {sw.Elapsed}");
    }
    public static void RunTasksOutter(int num) => Task.WaitAll(Enumerable.Range(0, num).Select(x => Task.Run(() => RunTasksInner(10))).ToArray());
    public static void RunTasksInner(int num) => Task.WaitAll(Enumerable.Range(0, num).Select(x => Task.Run(() => Thread.Sleep(10000))).ToArray());
