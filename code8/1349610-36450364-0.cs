    Action<long> action = (milliseconds) =>
    {
        Console.WriteLine("Running for {0}ms", milliseconds);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        while (watch.Elapsed.TotalMilliseconds <= milliseconds)
        {
            Console.WriteLine("ticks:{0}", DateTime.Now.Ticks);
            Thread.Sleep(100);
        }
        Console.WriteLine("Done");
        watch.Stop();
    };
    Task.Run(() => action(1000));
