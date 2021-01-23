    var startTime = DateTime.UtcNow;
    try
    {
        using (var timeoutCancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(500)))
        {
            await collection.Find("{ _id : 1 }").ToListAsync(timeoutCancellationTokenSource.Token);
        }
    }
    catch (OperationCanceledException ex)
    {
        var endTime = DateTime.UtcNow;
        var elapsed = endTime - startTime;
        Console.WriteLine("Operation was cancelled after {0} seconds.", elapsed.TotalSeconds);
    }
