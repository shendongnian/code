    static void Main(string[] args)
    {
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
        {                                                     //  THIS
            t.Exception.Handle((e) => true);                  //  ISN'T
            Console.WriteLine("You have canceled the task");  //  EXECUTING
        }, TaskContinuationOptions.OnlyOnCanceled);
    
        Console.ReadLine();
        cancellationTokenSource.Cancel();
        task.Wait();
    
        Console.ReadLine();
    }
