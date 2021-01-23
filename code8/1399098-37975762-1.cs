    private const int MAX_PARALLELISM = 15
    public async Task ProcessEntries()
    {
        var block = new ActionBlock<Entry>(async (entry) => 
                                           {
                                               //This is now a "async Task" instead of a async void
                                           }, 
                                           new ExecutionDataflowBlockOptions 
                                           { 
                                               MaxDegreeOfParallelism = MAX_PARALLELISM,
                                               BoundedCapacity = MAX_PARALLELISM * 4
                                           });
        foreach(var entry in entries)
        {
            await block.SendAsync(entry);
        }
    
        block.Complete();
        await block.Completion;
    
        DoExtraWorkWhenDone();
    }
