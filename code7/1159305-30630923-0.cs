    public class ThingCache
    {
      private static readonly object _lockObj;
      public async Task<Thing> GetAsync(string key, Func<Task<Thing>> cacheMissResolver)
      {
        lock (_lockObj)
        {
          if (cache.Contains(key))
            return cache[key];
          var task = cacheMissResolver();
          _cache.Add(key, task);
        }
      }
    }
