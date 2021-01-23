    public static class CacheHelper
    {
        public static readonly object _SyncLock = new object();
        public static readonly _MemoryCache = MemoryCache.Default;
        
        public static int GetFirmwareLogicalDefinitionMapID(int firmwareVersionID, int logicalParameterDefinitionID)
        {
            int result = -1;
            
            // Build up the cache key
            string cacheKey = string.Format("{0}.{1}", firmwareVersionID, logicalParameterDefinitionID);
            
            // Check if the object is in the cache already
            if(_MemoryCache.Countains(cacheKey))
            {
                // It is, so read it and type cast it
                object cacheObject = _MemoryCache[cacheKey];
                
                if(cacheObject is int)
                {
                    result = (int)cacheObject;
                }
            }
            else
            {
                // The object is not in cache, aquire a sync lock for thread safety         
                lock(_SyncLock)
                {
                    // Double check that the object hasnt been put into the cache by another thread.
                    if(!_MemoryCache.Countains(cacheKey))
                    {
                        // Still not there, now Query the database
                        result = (from i in dataContext.LogicalMapTable
                                  where i.FwId == firmwareVersionID && i.LpDefId == logicalParameterDefinitionID
                                  select i.FlDefMapID).FirstOrDefault();
                                  
                         // Add the results to the cache so that the next operation that asks for this object can read it from ram
                        _MemoryCache.Add(new CacheItem(cacheKey, result), new CacheItemPolicy() { SlidingExpiration = new TimeSpan(0, 5, 0) });
                    }
                    else
                    {
                        // we lost a concurrency race to read the object from source, its in the cache now so read it from there.
                        object cacheObject = _MemoryCache[cacheKey];
                        if(cacheObject is int)
                        {
                            result = (int)cacheObject;
                        }
                    }
                }
            }
            
            // return the results
            return result;
        }
    }
