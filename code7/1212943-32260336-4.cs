    var foregroundScheduler = new NewThreadScheduler(ts => new Thread(ts) {IsBackground = false});
    var timer = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(10), foregroundScheduler);
    var expensive = timer.Select(i =>
    {
        // Converting to strings is an expensive operation
        Console.WriteLine("Doing an expensive operation");
        return string.Format("#{0}", i);
    }).Publish();
    var a = expensive.Where(s => int.Parse(s.Substring(1)) % 2 == 0).Select(s => new { Source = "A", Value = s });
    var b = expensive.Where(s => int.Parse(s.Substring(1)) % 2 != 0).Select(s => new { Source = "B", Value = s });
    var merged = Observable.Merge(a, b);
    merged.Where(x => x.Source.Equals("A")).Subscribe(s => Console.WriteLine("Subscriber A got: {0}", s));
    merged.Where(x => x.Source.Equals("B")).Subscribe(s => Console.WriteLine("Subscriber B got: {0}", s));
    expensive.Connect();
