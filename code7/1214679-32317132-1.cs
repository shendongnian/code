    public static Task MonitorQueueEmptyTask(
                             string queueName, CancellationTokenSource tokenSource)
    {
        return Task.Factory.StartNew<bool>(() =>
        {
            while (!QueueManager.IsQueueEmpty(queueName))
            {
                if (tokenSource.IsCancellationRequested)
                {                            
                    break;
                }
                Thread.Sleep(5000);
                throw new Exception("Throwing an error!");
            };
        }, tokenSource.Token, TaskCreationOptions.LongRunning).ContinueWith(faultedTask =>
        {
            WriteExceptionToLog(faultedTask.Exception); 
        }, TaskContinuationOptions.OnlyOnFaulted); 
    }
