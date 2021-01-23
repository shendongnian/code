    static void Main(string[] args)
    {
        var interval = Observable.IntervalTimeSpan.FromSeconds(1));
        var sourcesOvertime = new [] {
            // Yield the first source after one second
            Observable.Return(interval).Delay(TimeSpan.FromSeconds(1)),
            // Yield the second source after five seconds
            Observable.Return(interval).Delay(TimeSpan.FromSeconds(5))
        };
        sourcesOvertime
            // merge these together so we end up with a "stream" of our source observables
            .Merge()
            // Now only listen to the latest one.
            .SwitchLatest()
            // Feed the values from the latest source to the console.
            .Subscribe(Console.WriteLine);
        Console.ReadKey();
    }
