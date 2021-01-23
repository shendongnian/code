    var cachedItem = (string)this.GetDataFromCache(cache, cacheKey);
    if (String.IsNullOrEmpty(object)) { // if no cache yet, or is expired
       lock (_lock) { // we lock only in this case
          // you have to make one more check, another thread might have put item in cache already
          cachedItem = (string)this.GetDataFromCache(cache, cacheKey); 
          if (String.IsNullOrEmpty(object)) {
              //get the data. take 100ms
              SetDataIntoCache(cache, cacheKey, cachedItem, DateTime.Now.AddMilliseconds(500));
          }
       }
    }
