    int result = 0;
    Task.WaitAll(Enumerable.Range(0, 5)
        .Select(index => Task.Factory.StartNew(() =>
        {
            // Do thread things...
            Interlocked.Increment(ref result);
        })).ToArray());
    
    Console.WriteLine(result);
