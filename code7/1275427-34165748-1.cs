    private async Task MainTaskLoader()
    {
        var task1 = Task.Run(PerformInitialTagLoad);
        var task2 = Task.Run(SomethingElse);
        // Imagine we have many of these...
        await Task.WhenAll(task1, task2);
        InitializeDataHarvester();
    }
