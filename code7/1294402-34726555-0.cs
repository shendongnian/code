    public void Add(string key, object item, int duration)
    {
        if (duration > 0)
        {
             DataCacheHelper.DataCache.Put(key, item, new TimeSpan(0, 0, 0, 0, duration));
        }
        else
        {
             DataCacheHelper.DataCache.Put(key, item);
        }
    }
