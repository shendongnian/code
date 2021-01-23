    BlockingCollection<Action>[] _taskQ;
    private int taskCounter = -1;
    public Multithreading(int workerCount)
    {
        _taskQ = new BlockingCollection<Action>[workerCount];
        
        for (int i = 0; i < workerCount; i++)
        {
            int workerId = i;//To avoid closure issue
            _taskQ[workerId] = new BlockingCollection<Action>();
            Task.Factory.StartNew(()=> Consume(workerId));
        }
    }
    
    public void EnqueueTask(Action action)
    {
        int value = Interlocked.Increment(ref taskCounter);
        int index = value / 4;//Your own logic to find the index here    
        _taskQ[index].Add(action);
    }
    
    void Consume(int workerId)
    {
        foreach (Action action in _taskQ[workerId].GetConsumingEnumerable())
           action();// Perform task.
    }
