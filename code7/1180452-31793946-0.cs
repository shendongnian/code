    static Random rand = new Random();
    static void Main(string[] args) {
        var obs = Observable.Interval(TimeSpan.FromMilliseconds(250)).Do<long>(i =>
        {
            CancellationTokenSource source = new CancellationTokenSource(250);
            ReadNext(source.Token, i);
        }).Publish();
        var disp = obs.Connect();
        Console.ReadKey();
        disp.Dispose();
        Console.ReadKey();
    }
    static private void ReadNext(CancellationToken token, long actual) {
        int i = rand.Next(4);
        for(int j = 0; j < i; j++) {
            Thread.Sleep(100);
            if(token.IsCancellationRequested) {
                Console.WriteLine(string.Format("method cancelled. cycles: {0}, should be 3. Now should be last (2): {1}", i, j));
                return;
            }
        }
        Console.WriteLine(string.Format("method done in {0} cycles. Preserved index: {1}.", i, actual));
    }
