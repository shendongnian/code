    private static readonly object _Lock = new object();
    
    ...
    
    object = (string)this.GetDataFromCache(cache, cacheKey);
    
    if(object == null)
    {
       lock(_Lock)
       {
            object = (string)this.GetDataFromCache(cache, cacheKey);
            if(String.IsNullOrEmpty(object))
            {
               get the data // take 100ms
               SetDataIntoCache(cache, cacheKey, object, DateTime.Now.AddMilliseconds(500));
            }
       }
    }
    
    return object;
