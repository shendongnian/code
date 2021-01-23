    static Stopwatch _watch = Stopwatch.StartNew();
    static Timer _timer = null;
    static void Main(string[] args)
    {
        _timer = new Timer(Callback, null,200, Timeout.Infinite);
       Console.ReadLine();
    }
    private static void Callback(Object state)
    {
        TimeSpan s = _watch.Elapsed;
        _watch.Restart();
        Console.WriteLine("Done, took {0} secs.", s.TotalMilliseconds);
        _timer.Change(200, Timeout.Infinite);
    }
