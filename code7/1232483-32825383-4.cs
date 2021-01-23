    private Task ActionAsync()
    {
        var task1 = LongRunningOperationAsync();
        var task2 = LongRunningOperationAsync();
        var task3 = LongRunningOperationAsync();
        var task4 = LongRunningOperationAsync();
        var task5 = LongRunningOperationAsync();
        Task[] tasks = {task1, task2, task3, task4, task5};
        return Task.WhenAll(tasks);
    }
