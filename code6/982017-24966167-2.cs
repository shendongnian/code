    var block = new ActionBlock<Data>(
        async data => await ProcessDataAsync(data),
        new ExecutionDataflowBlockOptions
        {
            BoundedCapacity = 1000,
            MaxDegreeOfParallelism = Environment.ProcessorCount
        });
    
    using(var connection = new SqlConnection(...))
    {
        // ...
        while(await reader.ReadAsync().ConfigureAwait(false))
        {
            // ...
           await block.SendAsync(item);
        }
    }
    
