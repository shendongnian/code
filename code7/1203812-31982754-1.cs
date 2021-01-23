    private async Task MyAsyncFunction(...)
    {
        var tasks = new List<Task<int>>();
        for (int i=0; i<10; ++i)
        {
            tasks.Add(CalculateAsync(i, 2*i);
        }
        // while all ten tasks are slowly calculating do something useful
        // after a while you need the answer, await for all tasks to complete:
        await Task.WhenAll(tasks);
        // the result is in Task.Result:
        if (task[3].Result < 5) {...}
    }
