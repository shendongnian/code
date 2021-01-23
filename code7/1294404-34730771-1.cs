    public void Add(string key, object item, int duration)
    {
        lock(_myStaticLockObject) // Declare static lock object (new Object()) to use for preventing other threads to execute this code. 
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
