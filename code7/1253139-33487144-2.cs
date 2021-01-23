    public static AddExceptionEntry(Exception ex, string header = "")
    {
        Task t = Task.Factory.StartNew(() => AddExceptionEntry(ex, header));
        tasks.Add(t);
        
        WaitForExecutionAsync().ConfigureAwait(true);
    }
    public static async Task WaitForExecutionAsync()
    {
        if(tasks.Count >0) 
            await Task.WhenAll(tasks.ToArray());
        // Raise Event.
    }
