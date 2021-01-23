    private const int MAX_PARALLELISM = 15
    public async Task ProcessEntries(IEnumerable<Entry> entries)
    {
        var block = new ActionBlock<Entry>(async (entry) => 
                                           {
                                               //This is now a "async Task" instead of a async void
                                           }, 
                                           new ExecutionDataflowBlockOptions 
                                           { 
                                               MaxDegreeOfParallelism = MAX_PARALLELISM
                                           });
        foreach(var entry in entries)
        {
            await block.SendAsync(entry);
        }
    
        block.Complete();
        await block.Completion;
    
        DoExtraWorkWhenDone();
    }
