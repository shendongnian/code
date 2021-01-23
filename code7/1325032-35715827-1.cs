    var tokenSource = new CancellationTokenSource();
    var token = tokenSource.Token;
    var backgroundTask = Task.Run(() =>
    {
        Console.WriteLine("Background task started");
        long count = 0;
        while (!token.IsCancellationRequested)
        {
            count++;
        }
        Console.WriteLine("Background task cancelled");
        return count;
    }, token);
    Console.WriteLine("Back in main");
    Console.ReadKey();
    tokenSource.Cancel();
    Console.WriteLine("Counter: {0}", backgroundTask.Result);
    Console.ReadKey();
