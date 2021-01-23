    var Canceller = new CancellationTokenSource();
    var token = Canceller.Token;
    List<Task<int>> tasks = new List<Task<int>>();
    tasks.Add(new Task<int>(() => { Thread.Sleep(3000); token.ThrowIfCancellationRequested(); Console.WriteLine("{0}: {1}", DateTime.Now, 3); return 3; }, token));
    tasks.Add(new Task<int>(() => { Thread.Sleep(1000); token.ThrowIfCancellationRequested(); Console.WriteLine("{0}: {1}", DateTime.Now, 1); return 1; }, token));
    tasks.Add(new Task<int>(() => { Thread.Sleep(2000); token.ThrowIfCancellationRequested(); Console.WriteLine("{0}: {1}", DateTime.Now, 2); return 2; }, token));
    tasks.Add(new Task<int>(() => { Thread.Sleep(8000); token.ThrowIfCancellationRequested(); Console.WriteLine("{0}: {1}", DateTime.Now, 8); return 8; }, token));
    tasks.Add(new Task<int>(() => { Thread.Sleep(6000); token.ThrowIfCancellationRequested(); Console.WriteLine("{0}: {1}", DateTime.Now, 6); return 6; }, token));
    tasks.ForEach(x => x.Start());
    bool Result = Task.WaitAll(tasks.Select(x => x).ToArray(), 3000);
    Console.WriteLine(Result);
    Canceller.Cancel();
    try
    {
        Task.WaitAll(tasks.ToArray());
    }
    catch (AggregateException ex)
    {
        if (!(ex.InnerException is TaskCanceledException))
            throw ex.InnerException;
    }
    tasks.ToList().ForEach(x => { x.Dispose(); });
    tasks.Clear();
    tasks = null;
    Canceller.Dispose();
    Canceller = null;
