    public Task RunAsync() 
    {
        var result = Work();
        var stepTasks = result.Select(step => Task.Run(() => step.Run));
        return Task.WhenAll(steps);
    }
