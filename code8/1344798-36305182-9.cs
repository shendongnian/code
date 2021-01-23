    int workers, ports;
    ThreadPool.GetMinThreads(out workers, out ports);
    Console.WriteLine("Min workers = " + workers); // Prints 8 on my system.
    var sw = Stopwatch.StartNew();
    for (int i = 0; i < 100; ++i)
    {
        Task.Run(() =>
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started at time {sw.Elapsed}");
            Thread.Sleep(10000);
        });
    }
    Console.ReadLine();
