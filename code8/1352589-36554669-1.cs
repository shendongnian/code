    /// <summary>
    /// Waits asynchronously for the process to exit.
    /// </summary>
    /// <param name="process">The process to wait for cancellation.</param>
    /// <param name="cancellationToken">A cancellation token. If invoked, the task will return 
    /// immediately as canceled.</param>
    /// <returns>A Task representing waiting for the process to end.</returns>
    public static Task WaitForExitAsync(this Process process, 
        int milliseconds,
        CancellationToken cancellationToken = default(CancellationToken))
    {    
        return Task.Run(() => process.WaitForExit(milliseconds), cancellationToken);
    }
