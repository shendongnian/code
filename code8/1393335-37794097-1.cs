    ActionBlock<QueueItem> _processor;
    Task _completionTask;
    bool _done;
    async Task ReadQueueAsync(int pollingInterval)
    {
         while (!_done)
         { 
             // Get a list of items to process from SQL database
            var list = ...;
            // Schedule the work 
            foreach(var item in list) 
            {
              _processor.Post(item);
            }
           
           // Give SQL server time to re-fill the queue
           await Task.Delay(pollingInterval);
         }
         // Signal the processor that we are done
         _processor.Complete();
    }
    void ProcessItem(QueueItem item)
    {
          // Do your work here
    } 
    void Setup()
    {
          // Configure action block to process items concurrently
          //  using all available CPU cores
         _processor= new ActionBlock<QueueItem>(new Action<QueueItem>(ProcessItem), 
             new    ExecutionDataFlowBlock{MaxDegreeOfParallelism =  DataFlowBlockOptions.Unbounded});
        _done = false;
        var queueReaderTask = ReadQueueAsync(QUEUE_POLL_INTERVAL);
        _completionTask = Task.WhenAll(queueReaderTask, _processor.Completion);   
    }
    void Complete()
    {
        _done = true;
        _completionTask.Wait();
    }
