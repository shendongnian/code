    private static void Main(string[] args)
    {
        var originSource = new Subject<string>();
        var subscription = UsingEventLoop(originSource)
            .Do(LongRunningAction) // runs on EventLoopScheduler thread
            .Subscribe();
    
        originSource.OnNext("First action (appears after 2 seconds)");
        originSource.OnNext("Second action (must not appear");
    
        Thread.Sleep(TimeSpan.FromSeconds(1));
        subscription.Dispose(); // Scheduler is still busy with first action!
    
        Console.WriteLine("Press any key to exit.");
        Console.ReadLine();
    }
    private static IObservable<TValue> UsingEventLoop<TValue>(IObservable<TValue> source)
    {
        return Observable.Using(
            () => new EventLoopScheduler(),
            scheduler => Observable.Create<TValue>((obs, ct) =>
            {
                return Task.FromResult(source.Subscribe(value =>
                {
                    // The following check+call is NOT thread safe!
                    if (!ct.IsCancellationRequested) 
                    {
                        scheduler.Schedule(() => obs.OnNext(value));
                    }
                }));
            }));
    }
    private static void LongRunningAction<TValue>(TValue value) {
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Console.WriteLine(value);
    }
