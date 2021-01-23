    var n = 4;
    var blockingQueue = new BlockingCollection<Request>(n);
    
    Action<Request> consumer = request => 
    {
        // do something with request.
    };
    
    var noOfWorkers = 4;
    var workers = new Task[noOfWorkers];
    
    for (int i = 0; i < noOfWorkers; i++)
    {
        var task = new Task(() =>
        {
            foreach (var item in blockingQueue.GetConsumingEnumerable())
            {
                consumer(item);
            }
        }, TaskCreationOptions.LongRunning | TaskCreationOptions.DenyChildAttach);
        workers[i] = task;
        workers[i].Start();
    }
    Task.WaitAll(workers);
