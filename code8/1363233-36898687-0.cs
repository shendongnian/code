    _queue = new BlockingCollection<KeyValuePair<string,object>>();
    // The poll task does pure protocol-polling
    // I assume that a read with no hardware data returns empty
    // IEnumerable of KeyValuePair (immediately)
    // You can have it async but thats because of the IO-operation, not
    // Because you're waiting for data. The polltask does what you want
    _pollTask = Task.Run(() =>
    {
        while(!token.IsCancellationRequested)
        {
            var newValues = this.connection.Read(valuesToRead);
            foreach(var newValue in newValues)
            {
                // Next, I try to add new data and wait max 1 second
                // if the queue is full to wait for the second task to read
                if(!_queue.TryAdd(newValue, 1000, token))
                {
                     if(!token.IsCancellationRequested)
                     {
                         // Log that queue was full
                     }
                }
            }
            token.WaitHandle.WaitOne(100); // Sleeps 100ms    
        }
    }
    //
    // The read task blocks forever (at TryTake) if no data exists (has been written
    // by the poll-task), and executes check for changed values and updates
    // the gui if, and only if, new data actually exists
    _readTask = Task.Run(() =>
    {
        while(!token.IsCancellationRequested)
        {
            KeyValuePair<string, object> nextItem;
            if(_queue.TryTake(out nextItem, Timeout.Infinite, token))
            {
                if(!token.IsCancellationRequested && this.ValueChanged(nextItem, oldValues) 
                {
                     this.Update(nextItem);
                }
            }
        }
    }
