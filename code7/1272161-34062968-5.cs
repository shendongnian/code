    var workerCount = 2;
    BlockingCollection<String>[] filesQueues= new BlockingCollection<String>[workerCount];
    for(int i = 0; i < workerCount; i++)
    {
        filesQueues[i] = new BlockingCollection<String>(500);
    
        // Worker
        Task.Run(() => 
        {
            while (!filesQueues[i].IsCompleted)
            {
                string url;
    
                try
                {
                    url= filesQueues[i].Take();
                }
                catch (InvalidOperationException) { }
    
                if (!string.IsNullOrWhiteSpace(url))
                {
                    calculateChecksum(url);
                }
            }
        }
    }
