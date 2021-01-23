    Stopwatch watch;
    using (ProcessorAffinity.BeginAffinity(0))
    {
        watch = Stopwatch.StartNew();
        for (int i = 0; i < threadsCount; i++)
        {
            Thread t = new Thread(IntensiveWork);
            t.IsBackground = true;
            threads[i] = t;
        }
        watch.Stop();
        Console.WriteLine("Creating took {0} ms", watch.ElapsedMilliseconds);
    }
