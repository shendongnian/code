    foreach (var msg in batchingQueue.GetConsumingEnumerable())
    {
        // process the message
        Console.WriteLine("Completing message");
        msg.Complete();
        lock (_listLock)
        {
            _recordBuffer.Add(msg);
            if (_recordBuffer.Count >= MaxBufferItems)
            {
                // Stop the timer
                _flushTimer.Change(Timeout.Infinite, Timeout.Infinite);
                // Save the old list and allocate a new one
                var myList = _recordBuffer;
                _recordBuffer = new List<BrokeredMessage>();
                // Start a task to write to the database
                Task.Factory.StartNew(() => FlushBuffer(myList));
                // Restart the timer
                _flushTimer.Change(FlushDelay.TotalMilliseconds, Timeout.Infinite);
            }
        }
    }
    private void TimedFlush()
    {
        bool lockTaken = false;
        List<BrokeredMessage> myList = null;
        try
        {
            if (Monitor.TryEnter(_listLock, 0, out lockTaken))
            {
                // Save the old list and allocate a new one
                myList = _recordBuffer;
                _recordBuffer = new List<BrokeredMessage>();
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor.Exit(_listLock);
            }
        }
        if (myList != null)
        {
            FlushBuffer(myList);
        }
        
        // Restart the timer
        _flushTimer.Change(FlushDelay.TotalMilliseconds, Timeout.Infinite);
    }
