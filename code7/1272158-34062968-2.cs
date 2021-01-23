    BlockingCollection<String> files= new BlockingCollection<String>(500);
    
    
    // Worker
    Task.Run(() => 
    {
        while (!files.IsCompleted)
        {
            string url;
    
            try
            {
                url= files.Take();
            }
            catch (InvalidOperationException) { }
    
            if (!string.IsNullOrWhiteSpace(url))
            {
                calculateChecksum(url);
            }
        }
    }
