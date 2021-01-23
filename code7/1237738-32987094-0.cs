    thread = new Thread(obj =>
    {
        SetSynchronizationContext(obj as SynchronizationContext);
        hack.Set();
        try
        {
            Debug.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + " - awaiting queue available...");
            while (true)
            {
                Debug.WriteLine("awaiting queue item...");
                var workItem = syncQueue.TryDequeue();
                Debug.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + " - queue item received!");
                if (!workItem.Success)
                    break;
                workItem.Item.Key(workItem.Item.Value);
            }
            Debug.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + " - queue finished :(");
        }
        catch (ObjectDisposedException e)
        {
            Debug.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + " - queue exception :((");
        }
    });
