    public void Write()
    {
        var tasks = new List<Task>();
        while (...)
        {
            var memoryStream = new MemoryStream(...);
            var task = WritePagesAsync(memoryStream, ...);
            tasks.Add(task);
        }
        Task.WaitAll(tasks.ToArray());
    }
    private async Task WritePagesAsync(MemoryStream memoryStrem, ...)
    {
        await _pageBlob.WritePagesAsync(memoryStrem);
        memoryStrem.Dispose();
    }
