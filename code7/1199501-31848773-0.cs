    /// <summary>
    /// Cache Manager Singleton
    /// </summary>
    public class CacheManager
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static MemoryCache instance = null;
        /// <summary>
        /// Gets the instance of memoryCache.
        /// </summary>
        /// <value>The instance of memoryCache.</value>
        public static MemoryCache Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemoryCache();
                }
                return instance;
            }
        }
    }
    /// <summary>
    /// Cache Manager
    /// </summary>
    public class MemoryCache
    {
        /// <summary>
        /// Gets the expiration date of the object
        /// </summary>
        /// <value>The no absolute expiration.</value>
        public DateTime NoAbsoluteExpiration
        {
            get { return DateTime.MaxValue; }
        }
        /// <summary>
        /// Retrieve the object in cache
        /// If the object doesn't exist in cache or is obsolete, getItemCallback method is called to fill the object
        /// </summary>
        /// <typeparam name="T">Object Type to put or get in cache</typeparam>
        /// <param name="httpContext">Http Context</param>
        /// <param name="cacheId">Object identifier in cache - Must be unique</param>
        /// <param name="getItemCallback">Callback method to fill the object</param>
        /// <param name="slidingExpiration">Expiration date</param>
        /// <returns>Object put in cache</returns>
        public T Get<T>(string cacheId, Func<T> getItemCallback, TimeSpan? slidingExpiration = null) where T : class
        {
            T item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemCallback();
                if (slidingExpiration == null)
                {
                    slidingExpiration = TimeSpan.FromSeconds(30);
                }
                HttpRuntime.Cache.Insert(cacheId, item, null, this.NoAbsoluteExpiration, slidingExpiration.Value);
            }
            return item;
        }
        /// <summary>
        /// Retrieve the object in cache
        /// If the object doesn't exist in cache or is obsolete, null is returned
        /// </summary>
        /// <typeparam name="T">Object Type to put or get in cache</typeparam>
        /// <param name="httpContext">Http Context</param>
        /// <param name="cacheId">Object identifier in cache - Must be unique</param>
        /// <returns>Object put in cache</returns>
        public T Get<T>(string cacheId) where T : class
        {
            T item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                return null;
            }
            return item;
        }
        /// <summary>
        /// Delete an object using his unique id
        /// </summary>
        /// <param name="httpContext">Http Context</param>
        /// <param name="cacheId">Object identifier in cache</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool Clear(string cacheId)
        {
            var item = HttpRuntime.Cache.Get(cacheId);
            if (item != null)
            {
                HttpRuntime.Cache.Remove(cacheId);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Delete all object in cache
        /// </summary>
        /// <param name="httpContext">Http Context</param>
        public void ClearAll(string filter = null)
        {
            var item = HttpRuntime.Cache.GetEnumerator();
            while (item.MoveNext())
            {
                DictionaryEntry entry = (DictionaryEntry)item.Current;
                var key = entry.Key.ToString();
                if (filter != null && (key.ToLower().Contains(filter.ToLower()) || filter == "*" )) //if filter, only delete if the key contains the filter value
                {
                    HttpRuntime.Cache.Remove(entry.Key.ToString());
                }
                else if (filter == null) //no filter, delete everything
                {
                    HttpRuntime.Cache.Remove(entry.Key.ToString());
                }
            }
        }
    }
