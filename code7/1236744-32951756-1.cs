    async public Task<ResultType> CallMethodAsync()
    {
        List<Task<SingleResultType>> tasks = new List<Task<SingleResultType>>();
        foreach(var obj in input)
        {
            tasks.Add(await CallDatabaseAsync(obj));
        }
        await Task.WhenAll(tasks);
        foreach(SingleResultType result in tasks.Select(t=>t.Result))
        {
            // combine results if needed
        }
        // return combined results    
    }
    
