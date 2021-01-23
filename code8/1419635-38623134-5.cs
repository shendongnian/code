       private static Void FillCache(UsageSummary usage)
        {
            try
            {
                AccumulateChildFolders(summary.Folder, summary);
                CacheResults(summary);
                // Now we start a watch on the volume that 
                // can invalidate cache entries when changes occur.
                _watcher.WatchVolume(summary.Folder);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "CacheTotalUsage: {1}", ex.Message);
            }
        }
