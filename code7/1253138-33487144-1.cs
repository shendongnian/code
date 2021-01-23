    public static AddExceptionEntry(Exception ex, string header = "")
    {
        Task t = Task.Factory.StartNew(() => AddExceptionEntry(ex, header));
        tasks.Add(t);
        
        WaitForExecution().ConfigureAwait(true);
    }
    public static async Task WaitForExecution()
    {
         await Task.WhenAll(tasks.ToArray());
        // Raise Event.
    }
