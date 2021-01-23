    public async Task RunAsync() 
    {
        var result = Work();
        var stepTasks = result.Select(step => Task.Run(() => step.Run));
        await Task.WhenAll(steps);
    }
