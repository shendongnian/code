        public static MemoryCacheItemInfo[] GetCacheItemInfo(this MemoryCache cache)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            FieldInfo field = typeof (MemoryCache).GetField("_stores", bindFlags);
            object[] cacheStores = (object[]) field.GetValue(cache);
            List<MemoryCacheItemInfo> info = new List<MemoryCacheItemInfo>();
            foreach (object cacheStore in cacheStores)
            {
                Type cacheStoreType = cacheStore.GetType();
                FieldInfo lockField = cacheStoreType.GetField("_entriesLock", bindFlags);
                
                object lockObj = lockField.GetValue(cacheStore);
                lock (lockObj)
                {
                    FieldInfo entriesField = cacheStoreType.GetField("_entries", bindFlags);
                    Hashtable entriesCollection = (Hashtable) entriesField.GetValue(cacheStore);
                    foreach (DictionaryEntry cacheItemEntry in entriesCollection)
                    {
                        Type cacheItemValueType = cacheItemEntry.Value.GetType();
                        string key = (string) cacheItemEntry.Key.GetType().GetProperty("Key", bindFlags).GetValue(cacheItemEntry.Key);
                        PropertyInfo value = cacheItemValueType.GetProperty("Value", bindFlags);
                        PropertyInfo utcCreated = cacheItemValueType.GetProperty("UtcCreated", bindFlags);
                        PropertyInfo utcLastUpdateUsage = cacheItemValueType.GetProperty("UtcLastUpdateUsage", bindFlags);
                        PropertyInfo utcAbsoluteExpiry = cacheItemValueType.GetProperty("UtcAbsExp", bindFlags);
                        PropertyInfo utcSlidingExpiry = cacheItemValueType.GetProperty("SlidingExp", bindFlags);
                        MemoryCacheItemInfo mcii = new MemoryCacheItemInfo(
                            key,
                            value.GetValue(cacheItemEntry.Value),
                            ((DateTime) utcCreated.GetValue(cacheItemEntry.Value)).ToLocalTime(),
                            ((DateTime) utcLastUpdateUsage.GetValue(cacheItemEntry.Value)).ToLocalTime(),
                            ((DateTime) utcAbsoluteExpiry.GetValue(cacheItemEntry.Value)).ToLocalTime(),
                            ((TimeSpan) utcSlidingExpiry.GetValue(cacheItemEntry.Value))
                            );
                        info.Add(mcii);
                    }
                }
            }
            return info.ToArray();
        }
