    public class ThingCache
    {
      private static readonly object _lockObj;
      public async Task<Thing> GetAsync(string key, Func<Task<Thing>> cacheMissResolver)
      {
        lock (_lockObj)
        {
          if (cache.Contains(key))
          {
            if (cache[key].Status == TaskStatus.RanToCompletion)
              return cache[key];
            cache.Remove(key);
          }
          var task = cacheMissResolver();
          _cache.Add(key, task);
        }
      }
    }
