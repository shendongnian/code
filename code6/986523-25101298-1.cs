    static void Main(string[] args)
    {
        var streams = new [] {
                Observable.Empty<long>().Delay(TimeSpan.FromSeconds(1)),
                Observable.Interval(TimeSpan.FromSeconds(1)),
                Observable.Empty<long>().Delay(TimeSpan.FromSeconds(5)),
                Observable.Interval(TimeSpan.FromSeconds(1))
            }
            .ToObservable()
            .Switch()
            .Subscribe(Console.WriteLine);
        Console.ReadKey();
    }
