    var filter = new HttpBaseProtocolFilter
    {
        CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent,
        CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
    }
