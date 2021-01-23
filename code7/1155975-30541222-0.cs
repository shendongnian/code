    public class QueueVariables
    {
        public string Account {get;set;}
        public string File {get;set;}
    }
    
    public static ConcurrentQueue<string> GetACcounts()
    {
        return new ConcurrentQueue<string>(new []
            {
            "Account1",
            "Account2",
            "Account3",
            "Account4",
            "Account5",
            "Account6",
            "Account7",
            "Account8",
            "Account9",
            "Account10",
            "Account11",
            "Account12",
        });
    }
    
    public static List<string> GetFiles(string acct)
    {
        return new List<string>
        {
            "File1",
            "File2",
            "File3",
            "File4",
            "File5",
            "File6",
            "File7",
            "File8",
            "File9",
            "File10",
            "File11",
            "File12",
        };
    }
    
    public static async Task StartPeriodicProducers(int numProducers, TimeSpan period, CancellationToken ct)
    {
        while(!ct.IsCancellationRequested)
        {
            var producers = StartProducers(numProducers, ct);
    
            // wait for production to finish
            await Task.WhenAll(producers.ToArray());
    
            // wait before running again
            Console.WriteLine("***Waiting " + period);
            await Task.Delay(period, ct);
        }
    }
    
    public static List<Task> StartProducers(int numProducers, CancellationToken ct)
    {
        List<Task> producingTasks = new List<Task>();
        var accounts = GetACcounts();
    
        for (int i = 0; i < numProducers; i++)
        {
            producingTasks.Add(Task.Run(async () =>
            {
                string acct;
                while(accounts.TryDequeue(out acct) && !ct.IsCancellationRequested)
                {
                    foreach (var file in GetFiles(acct))
                    {
                        _orderQ.Add(new UserQuery.QueueVariables{ Account = acct, File = file });
                        Console.WriteLine("Produced Account:{0} File:{1}", acct, file);
                        await Task.Delay(50, ct); // simulate production delay
                    }
                }
    
                Console.WriteLine("Finished producing");
            }));
        }
    
        return producingTasks;
    }
    
    public static List<Task> StartConsumers(int numConsumers)
    {
        List<Task> consumingTasks = new List<Task>();
    
        for (int j = 0; j < numConsumers; j++)
        {
            consumingTasks.Add(Task.Run(async () =>
            {
                try
                {
                    while(true)
                    {
                        var queueVar = _orderQ.Take();
                        Console.WriteLine("Consumed Account:{0} File:{1}", queueVar.Account, queueVar.File);
                        await Task.Delay(200); // simulate consumption delay
                    }
                }
                catch(InvalidOperationException)
                {
                    Console.WriteLine("Finished Consuming");
                }
            }));
        }
    
        return consumingTasks;
    }
    
    private static async Task MainAsync()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        var periodicProducers = StartPeriodicProducers(2, TimeSpan.FromSeconds(10), cts.Token);
        var consumingTasks = StartConsumers(4);
    
        await Task.Delay(TimeSpan.FromSeconds(120));
    
        // stop production
        cts.Cancel();
    
        try
        {
            // wait for producers to finish producing
            await periodicProducers;
        }
        catch(OperationCanceledException)
        {
            // operation was cancelled
        }
    
        // complete adding to release blocked consumers
        _orderQ.CompleteAdding();
    
        // wait for consumers to finish consuming
        await Task.WhenAll(consumingTasks.ToArray());
    }
    
    // maximum size 10, after that capaicity is reached the producers block
    private static BlockingCollection<QueueVariables> _orderQ = new BlockingCollection<QueueVariables>(10);
    
    void Main()
    {
        MainAsync().Wait();
        Console.ReadLine();
    }
    
    // Define other methods and classes here
