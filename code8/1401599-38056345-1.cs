    [Test]
    public void TestObserveOn()
    {
        Console.WriteLine("Starting on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
        var source = new Subject<object>();
        var exclusiveScheduler = new EventLoopScheduler();
        var are = new AutoResetEvent(false);
        using (source.ObserveOn(exclusiveScheduler).OfType<int>().Subscribe(
            o =>
                {
                    Console.WriteLine("Received {1} on threadId:{0}", Thread.CurrentThread.ManagedThreadId, o);
                    int sleep = 3000 / o;
                    Thread.Sleep(sleep);
                    Console.WriteLine("Handled  {1} on threadId: {0}", Thread.CurrentThread.ManagedThreadId, o);
                },
            () =>
                {
                    Console.WriteLine("OnCompleted on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
                    are.Set();
                }))
        using (source.ObserveOn(exclusiveScheduler).OfType<double>().Subscribe(
                        o =>
                            {
                                Console.WriteLine(
                                    "Received {1} on threadId:{0}",
                                    Thread.CurrentThread.ManagedThreadId,
                                    o);
                                Console.WriteLine(
                                    "Handled  {1} on threadId: {0}",
                                    Thread.CurrentThread.ManagedThreadId,
                                    o);
                            },
                        () =>
                        {
                            Console.WriteLine("OnCompleted on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
                            are.Set();
                        }))
        {
            Console.WriteLine("Subscribed on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
            source.OnNext(1);
            source.OnNext(1.1);
            source.OnNext(2);
            source.OnNext(2.1);
            source.OnNext(3);
            source.OnNext(3.1);
            source.OnCompleted();
            Console.WriteLine("Finished on threadId:{0}", Thread.CurrentThread.ManagedThreadId);
            are.WaitOne();
            are.WaitOne();
        }
    }
