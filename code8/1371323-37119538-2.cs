    using System;
    using System.Collections.Generic;
    using System.Web;
    
    namespace Core.Helpers
    {
        public static class CacheHelper
        {
            public static List<string> GetCacheKeys()
            {
                List<string> keys = new List<string>();
                // retrieve application Cache enumerator
                var enumerator = System.Web.HttpRuntime.Cache.GetEnumerator();
    
                while (enumerator.MoveNext())
                {
                    keys.Add(enumerator.Key.ToString());
                }
    
                return keys;
            }
    
            /// <summary>
            /// Insert value into the cache using
            /// appropriate name/value pairs
            /// </summary>
            /// <typeparam name="T">Type of cached item</typeparam>
            /// <param name="o">Item to be cached</param>
            /// <param name="key">Name of item</param>
            public static void Add<T>(T o, string key)
            {
                // NOTE: Apply expiration parameters as you see fit.
                // I typically pull from configuration file.
    
                // In this example, I want an absolute
                // timeout so changes will always be reflected
                // at that time. Hence, the NoSlidingExpiration.
                if (HttpContext.Current != null)
                HttpContext.Current.Cache.Insert(
                    key,
                    o,
                    null,
                    DateTime.Now.AddMinutes(1440),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
    
            /// <summary>
            /// Remove item from cache
            /// </summary>
            /// <param name="key">Name of cached item</param>
            public static void Clear(string key)
            {
                if (HttpContext.Current != null)
                HttpContext.Current.Cache.Remove(key);
            }
    
            /// <summary>
            /// Check for item in cache
            /// </summary>
            /// <param name="key">Name of cached item</param>
            /// <returns></returns>
            public static bool Exists(string key)
            {
                var exists= HttpContext.Current != null && HttpContext.Current.Cache[key] != null;
                return exists;
            }
    
            /// <summary>
            /// Retrieve cached item
            /// </summary>
            /// <typeparam name="T">Type of cached item</typeparam>
            /// <param name="key">Name of cached item</param>
            /// <param name="value">Cached value. Default(T) if
            /// item doesn't exist.</param>
            /// <returns>Cached item as type</returns>
            public static bool Get<T>(string key, out T value)
            {
                try
                {
                    if (!Exists(key))
                    {
                        value = default(T);
                        return false;
                    }
    
                    value = (T)HttpContext.Current.Cache[key];
                }
                catch
                {
                    value = default(T);
                    return false;
                }
    
                return true;
            }
        }
    }
