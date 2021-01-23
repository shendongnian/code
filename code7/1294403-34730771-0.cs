    public void Add(string key, object item, int duration)
    {
        lock(_myStaticLockObject)
        {
            if (DataCacheHelper.DataCache.Get(key) == null)
            {
                if (duration > 0)
                {
                    DataCacheHelper.DataCache.Add(key, item, new TimeSpan(0, 0, 0, 0, duration));
                }
                else
                {
                    DataCacheHelper.DataCache.Add(key, item);
                }
            }
            else
            {
                Update(key, item);
            }
        }
    }
