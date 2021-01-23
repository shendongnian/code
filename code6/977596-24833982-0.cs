    public void Shutdown()
    {
        Logger.Log(LogLevel.Debug, "Preparing to stop UploadQueue");
        IsProcessing = false;
        //Set tasks to cancel to prevent queued tasks from parsing
        _cancellationTokenSource.Cancel();
        Logger.Log(LogLevel.Debug, "Waiting for " + _workerTasks.Count + " tasks to finish or cancel.");
         try
         {
             //Wait for tasks to finish
             Task.WaitAll(_workerTasks.Values.ToArray());
             Logger.Log(LogLevel.Debug, "Stopped UploadQueue");
         }
         catch (AggregationException e)
         {
             // Recover from the exception
         }
    }
