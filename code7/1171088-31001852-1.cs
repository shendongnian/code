    private static void Main()
    {
        MainAsync().Wait();
    }
    private static async Task MainAsync()
    {
        var block = new ActionBlock<string>(async item =>
        {
            Console.WriteLine(item.Substring(0, 10));
            await Task.Delay(1000);
        }, new ExecutionDataflowBlockOptions { BoundedCapacity = 1 });
        foreach (var item in GetSequence('A'))
        {
            await block.SendAsync(item);
        }
        block.Complete();
        await block.Completion;
    }
