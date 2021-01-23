    var block = new ActionBlock<string>(str =>
    {
        //save in db
    }, new ExecutionDataflowBlockOptions
    {
        MaxDegreeOfParallelism = 6
    });
    var sendings = new List<Task<bool>>
    {
        block.SendAsync("a"),
        block.SendAsync("b"),
        block.SendAsync("c")
    };
    await Task.WhenAll(sendings);
    block.Complete();       // tell the block we're done sending messages
    await block.Completion; // wait for messages to be processed
