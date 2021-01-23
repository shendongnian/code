    // No async, since there's no await
    private static void AsyncCacheUsage(UsageSummary summary)
    {
      try
      {
        AccumulateChildFolders(summary.Folder, summary);
        CacheResults(summary);
        _watcher.WatchVolume(summary.Folder);
      }
      catch (Exception ex)
      {
        Log.Error(ex, "CacheTotalUsage: {1}", ex.Message);
      }
    }
    // No async, since there's no awaits
    public static UsageSummary GetTotalUsage(string folder)
    {
      UsageSummary totalUsage = null;
      if (!IsCached(folder, ref totalUsage))
      {
        totalUsage = GetFileUsage(folder);
        AsyncCacheUsage(totalUsage); // No await anymore
      }
      return totalUsage;
    }
    if (FileHelper.IsFolder(info))
    {
      UsageSummary usage = DiskUsage.GetTotalUsage(info.FullName);
      totalSize += usage.TotalSize;
    }
    else
    {
      totalSize += info.Length;
    }
