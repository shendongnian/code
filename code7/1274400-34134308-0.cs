    CancellationTokenSource cancellationTokenSource =
            new CancellationTokenSource();
    CancellationToken token = cancellationTokenSource.Token;
    Task task = Task.Run(() =>
    {
       while (!token.IsCancellationRequested)
       {
          ThreadAutoCalling();
       }
       token.ThrowIfCancellationRequested();
    }, token);
    try
       {
          Console.WriteLine("Press any key to abort the task");
          Console.ReadLine();
          cancellationTokenSource.Cancel();
          task.Wait();
       }
    catch (AggregateException e)
    {
         Console.WriteLine(e.InnerExceptions[0].Message);
    }
