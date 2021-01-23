    private BlockingCollection<int> bq = new BlockingCollection<int>();
    void Test()
    {
        // create two consumers
        var c1 = new Thread(Consume);
        var c2 = new Thread(Consume);
        c1.Start();
        c2.Start();
        // produce
        for (var i = 0; i < 100; ++i)
        {
            bq.Add(i);
        }
        bq.CompleteAdding();
        c1.Join();
        c2.Join();
    }
    void Consume()
    {
        foreach (var i in bq.GetConsumingEnumerable())
        {
            Console.WriteLine("Consumed-" + i);
            Thread.Sleep(1000);
        }
    }
