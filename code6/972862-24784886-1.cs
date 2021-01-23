    public async Task<List<string>> Get()
    {
        var task1 = Method1ResultProcessorAsync(Method1Async());
        var task2 = Method2ResultProcessorAsync(Method2Async());
    
        var tasks = new[] { task1, task2 };
        try
        {
            await Task.WhenAll(tasks);
        }
        catch {}
        var results = tasks.Where(t => t.Status == TaskStatus.RanToCompletion)
                           .Select(t => t.Result)
                           .ToList();
        if (results.Any())
            return results;
        // or maybe another exception,
        // since await handles AggregateException in a weird way
        throw new AggregateException(tasks.Select(t => t.Exception));
    }
