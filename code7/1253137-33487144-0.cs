    public static AddExceptionEntry(Exception ex, string header = "")
    {
        Task t = Task.Factory.StartNew(() => AddExceptionEntry(ex, header));
        tasks.Add(t);
    }
    public static async Task WaitForExecution()
    {
         await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);
        // Raise Event.
    }
