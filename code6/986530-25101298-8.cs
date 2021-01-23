    static void Main(string[] args)
    {
        var streams = new Subject<IObservable<long>>();
        // Subscribe before binding the source stream.
        streams.Switch().Subscribe(Console.WriteLine);
        Thread.Sleep(1000);
        // Bind a source stream.
        streams.OnNext(Observable.Interval(TimeSpan.FromSeconds(1)));
        Thread.Sleep(5000);
        // Bind a new source stream.
        streams.OnNext(Observable.Interval(TimeSpan.FromSeconds(1)));
        Console.ReadKey();
    }
