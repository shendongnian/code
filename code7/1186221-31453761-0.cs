    async Task MainAsync()
    {
        var ints = Enumerable.Range(0, 125).ToList();
        var batchBlock = new BatchBlock<int>(50, new GroupingDataflowBlockOptions { BoundedCapacity = 100 });
        var actionBlock = new ActionBlock<int[]>(intsBatch =>
        {
            Thread.Sleep(1000);
            foreach (var i in intsBatch)
                Console.WriteLine(i);
        });
        batchBlock.LinkTo(actionBlock, new DataflowLinkOptions { PropagateCompletion = true });
        foreach (var i in ints)
            await batchBlock.SendAsync(i); // wait synchronously for the block to accept.
        batchBlock.Complete();
        await actionBlock.Completion;
    }
