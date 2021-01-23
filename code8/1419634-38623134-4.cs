      public static long GetTotalUsage(string folder)
      {
        UsageSummary usage = null;
        if (!IsCached(folder, ref usage))
        {
            // Not cached, get first-level usage
            usage = GetFileUsage(folder);
            
            try
                {
                    // Start task to FillCache for this folder.
                    Log.Info("Start FillCache: {0}", folder);
                    var cacheTask = new Task(() => FillCache(usage), TaskCreationOptions.LongRunning);
                    cacheTask.Start();
                }
                catch (Exception ex)
                {
                    DuLog.Error(ex, "!!! Run cacheTask: {0}", ex.Message);
                }
         
        }
        // Was cached, or we got the first-level results.
        // Race condition. FillCache() is updating usage.TotalSize.
        return usage.TotalSize;
    }
