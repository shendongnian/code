    public async Task TransferAndWaitStartedAsync()
    {
        var transferTask = new TransferTask();
        // Prepare the observable before executing the transfer to make sure that the observable sequence will receive the event
        // You can use Linq operators to filter only specific events. In this case, I only care about events with Status == StatusCode.Started 
        var whenStatusChanged = Observable.FromEventPattern<TransferStatusChangedEventArgs>(h, transferTask.StatusChanged += h, h => transferTask.StatusChanged -= h)
                                          .Where(e => e.EventArgs.Status == StatusCode.Started)
                                          .FirstAsync();
         // Start the transfer asynchronously
         await transferTask.TransferAsync(); 
         
         // Continuation will complete when receiving the first event that matches the predicate in the observable sequence even if the event was triggered too quickly.
         await whenStatusChanged; 
    }
