    public void Add(LogMessageHandler l, string msg)
    {
        if (queue.Count < MaxLogQueueSize) 
        {
            queue.Enqueue(new Tuple<LogMessageHandler, string>(l, msg));
            waiter.Set();
        }
    }
