    static Thread thread1 = new Thread(new ThreadStart(Team1Shots));
    static Thread thread2 = new Thread(new ThreadStart(Team2Shots));
    static BlockingCollection<WorkerStateMessage> thread1Messages =
        new BlockingCollection<WorkerStateMessage>();
    static BlockingCollection<WorkerStateMessage> thread2Messages =
        new BlockingCollection<WorkerStateMessage>();
    static BlockingCollection<WorkerStateMessage> progressMessages =
        new BlockingCollection<WorkerStateMessage>();
    static void Main(string[] args)
    {
        thread1Messages.Add(new WorkerStateMessage { Type = MessageType.Work1, Data = 1 });
        thread1Messages.Add(new WorkerStateMessage { Type = MessageType.Work1, Data = 2 });
        thread1Messages.Add(new WorkerStateMessage { Type = MessageType.Work1, Data = 3 });
        thread1.Start();
        thread2.Start();
        // 4 step * 3 messages = 12 progress messages
        foreach(var message in progressMessages.GetConsumingEnumerable().Take(12))
        {
            Console.WriteLine(message.Progress);
            Console.WriteLine("Current data: {0}", message.Data);
        }
        
        thread1Messages.Add(WorkerStateMessage.Done);
        thread2Messages.Add(WorkerStateMessage.Done);
        thread1.Join();
        thread2.Join();
    }
