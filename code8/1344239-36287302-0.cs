    BlockingCollection<State> queue = new BlockingCollection<State>();
    
    updater = Task.Factory.StartNew(() =>
    {
        while (!cts.Token.IsCancellationRequested)
        {
            Thread.Sleep(1000);
            var newState = GetNewState();
            queue.Add(newState);
        }
    }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    
    for (int i = 0; i < 10; i++)
    {
        var readerId = i.ToString();
        readers.Add(Task.Factory.StartNew(() =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                // get it
                var readState = queue.Take(cts.Token);
                
                // use it
                if (readState != null)
                {
                    Console.WriteLine("Hello from reader #" + readerId);
                    Console.WriteLine(readState.X);
                }
            }
        }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default));
    }
