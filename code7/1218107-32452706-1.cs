    private string GetDataFromCache(
                ObjectCache cache, 
                string key, 
                Func<string> valueFactory)
    {
        var newValue = new Lazy<string>(valueFactory);            
        //The line below returns existing item or adds 
        // the new value if it doesn't exist
        var value = cache.AddOrGetExisting(key, newValue, DateTimeOffset.Now.AddMilliseconds(500)) as Lazy<string>;
        // Lazy<T> handles the locking itself
        return (value ?? newValue).Value;
    }
    // usage...
    object = this.GetDataFromCache(cache, cacheKey, () => {
          // get the data...
          // this method will be called only once..
          // Lazy will automatically do necessary locking
          return data;
    });
