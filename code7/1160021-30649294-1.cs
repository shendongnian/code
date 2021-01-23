    var block = new ActionBlock<WorkItem>(wi =>
    {
        DoWork(wi);
        await Task.WhenAll(DoSomeWorkAsync(wi), DoOtherWorkAsync(wi));
    }, 
    new ExecutionDataflowBlockOptions{ MaxDegreeOfParallelism = 1000 });
    
    foreach (var workItem in workItems)
    {
        block.Post(workItem);
    }
    
    block.Complete();
    await block.Completion;
