      public static long GetTotalUsage(string folder)
      {
        UsageSummary usage = null;
        if (!IsCached(folder, ref usage))
        {
            // Not cached, get first-level usage
            usage = GetFileUsage(folder);
            // Start task populate cache
            // No await.  No rendezvous. Fire and forget.
            Task.Run(() => FillCache(usage));
        }
        // Was cached, or we got the first-level results.
        // Race condition. FillCache() is updating usage.TotalSize.
        return usage.TotalSize;
    }
