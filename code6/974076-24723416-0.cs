    //create a cancellation token that will cancel itself after 3secs
    int timeout = 3000;
    var source = new CancellationTokenSource(timeout);
    var token = source.Token;
    List<Task> tasks = new List<Task>();
    for (int i = 0; i < 5; i++)
    {
        Task t = Task.Run(async () =>
            {
                //wait for 30 secs OR until cancellation is requested
                await Task.Delay(30000, token);
                Console.WriteLine(DateTime.Now.ToString() + "task finish");
            });
        tasks.Add(t);
    }
    printThreadCount("before waitall");
    try
    {
        Task.WaitAll(tasks.ToArray());
    }
    catch(AggregateException ex)
    {
        foreach (var e in ex.Flatten().InnerExceptions)
            Console.WriteLine(e.Message);
    }
    printThreadCount("after waitall");
