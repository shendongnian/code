    public async Task DoLotsOfWork(IEnumerable<Func<Task>> tasks)
    {
        foreach(var task in tasks)
            await task();
        Console.WriteLine("Finished");
    }
