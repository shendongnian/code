    static void Main(string[] args)
    {
        // var bindableStream = new BindableStream<long>();
        var bindableStream = new Subject<IObservable<long>>();
        var dest = bindableStream.Switch();
        // Subscribe before binding the source stream.
        // bindableStream.Subscribe(i => Console.WriteLine(i));
        dest.Subscribe(i => Console.WriteLine(i));
        Thread.Sleep(1000);
        // Bind a source stream.
        // bindableStream.Bind(Observable.Interval(TimeSpan.FromSeconds(1)));
        bindableStream.OnNext(Observable.Interval(TimeSpan.FromSeconds(1)));
        Thread.Sleep(5000);
        // Bind a new source stream.
        // bindableStream.Bind(Observable.Interval(TimeSpan.FromSeconds(1)));
        bindableStream.OnNext(Observable.Interval(TimeSpan.FromSeconds(1)));
        Thread.Sleep(4000);
        Console.WriteLine("Unbound!");
        // Unbind the source and dest streams.
        // bindableStream.Unbind();
        bindableStream.OnNext(Observable.Empty<long>());
        Console.ReadKey();
    }
