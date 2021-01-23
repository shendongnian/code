    block = new ActionBlock<MyItem>(item =>
    {
        using (var context = new MyDbContext())
        {
            context.MyItem.Add(item);
            // Run Calculations
           try {
               context.SaveChanges();
           }
           catch {
               // Log error
           }
        } 
    }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 2 });
    
    while (queue.Any())
    {
        var item = queue.Dequeue();
        block.Post(item);
    }
    
    block.Complete();
    await block.Completion;
