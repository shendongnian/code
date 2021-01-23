    var source1 = new BroadcastBlock<int>(z => z);
    var options = new DataflowLinkOptions { PropagateCompletion = true };
    // this block wouldn't execute, as it doesn't get the data with greedy execution
    var batch1 = new BatchBlock<int>(2, new GroupingDataflowBlockOptions { Greedy = false });
    var batch1Action = new ActionBlock<int[]>(arr =>
    {
        Console.WriteLine("Received from batch 1 block!");
        foreach (var item in arr)
        {
            Console.WriteLine("Received {0}", item);
        }
    });
    batch1.LinkTo(batch1Action, options);
    // this batch is freedy, so it will execute always
    var batch2 = new BatchBlock<int>(2);
    var batch2Action = new ActionBlock<int[]>(arr =>
    {
        Console.WriteLine("Received from batch 2 block!");
        foreach (var item in arr)
        {
            Console.WriteLine("Received {0}", item);
        }
    });
    batch2.LinkTo(batch2Action, options);
    // connect source(s)
    source1.LinkTo(batch1, options);
    source1.LinkTo(batch2, options);
    // fire
    source1.SendAsync(3);
    // simulate some over work
    Thread.Sleep(3000);
    // complete batch, now the ActionBlock2 will execute
    source1.SendAsync(3);
    // if you need to wait for completion, call this method
    source1.Complete();
    // note that WhenAll isn't blocking task
    var allTasks = Task.WhenAll(batch1Action.Completion, batch2Action.Completion);
    // non-blocking wait
    await allTasks;
    // blocking wait
    allTasks.Wait();
    Console.ReadLine();
