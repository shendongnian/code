    var block = new ActionBlock<SomeData>(
        _ => _repository.WriteDataAsync(_), // What to do on each item
        new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 10 }); // How many items at the same time
    foreach (var item in items)
    {
        block.Post(item); // Post all items to the block
    }
    block.Complete(); // Signal completion
    await block.Completion; // Asynchronously wait for completion.
    
