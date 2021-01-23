     CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    var token = cancellationTokenSource.Token;
    
    Task task = Task.Run(() =>
    {
        while (!token.IsCancellationRequested)
        {
            Console.Write("*");
            Thread.Sleep(1000);
        }
    }, token).ContinueWith((t) =>
    {
        t.Exception.Handle((e) => true);
        Console.WriteLine("You have canceled the task");
    }, TaskContinuationOptions.OnlyOnRanToCompletion);
    
    Console.ReadLine();
    cancellationTokenSource.Cancel();
       
    try
        {
            task.Wait();
        }
    catch (AggregateException e)
        {
            foreach (var v in e.InnerExceptions)
                Console.WriteLine(e.Message + " " + v.Message);
        }
    Console.ReadLine();
