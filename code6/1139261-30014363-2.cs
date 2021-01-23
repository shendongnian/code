    [HostProtection(ExternalThreading = true)]
    public Task SendMailAsync(MailMessage message)
    {
        // Create a TaskCompletionSource to represent the operation
        var tcs = new TaskCompletionSource<object>();
 
        // Register a handler that will transfer completion results to the TCS Task
        SendCompletedEventHandler handler = null;
        handler = (sender, e) => HandleCompletion(tcs, e, handler);
        this.SendCompleted += handler;
 
        // Start the async operation.
        try { this.SendAsync(message, tcs); }
        catch
        {
            this.SendCompleted -= handler;
            throw;
        }
 
        // Return the task to represent the asynchronous operation
        return tcs.Task;
    }
