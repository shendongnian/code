    public Task<string[]> Get()
    {
        var task1 = Method1ResultProcessorAsync(Method1Async());
        var task2 = Method2ResultProcessorAsync(Method2Async());
    
        return Task.WhenAll(task1, task2);
    }
