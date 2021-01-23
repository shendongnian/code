    public static ITargetBlock<T> CreateGuaranteedBroadcastBlock<T>(
        DataflowBlockOptions options, params ITargetBlock<T>[] targets)
    {
        var block = new ActionBlock<T>(
            async item =>
            {
                foreach (var target in targets)
                {
                    await target.SendAsync(item);
                }
            }, new ExecutionDataflowBlockOptions
            {
                BoundedCapacity = options.BoundedCapacity,
                CancellationToken = options.CancellationToken
            });
        block.Completion.ContinueWith(task =>
        {
            foreach (var target in targets)
            {
                if (task.Exception != null)
                    target.Fault(task.Exception);
                else
                    target.Complete();
            }
        });
        return block;
    }
