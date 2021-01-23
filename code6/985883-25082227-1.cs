    var broadcaster = new ActionBlock<int>(async num => 
    {
        var tasks = new List<Task>();
        foreach (var block in blocks)
        {
            tasks.Add(block.SendAsync(num));
        }
        await Task.WhenAll(tasks);
    }, execopt);
