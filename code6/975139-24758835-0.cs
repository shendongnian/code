    public static object LoadFile()
    {
        var filename = ParseFileNameFromHttpRequest();
        var a = loadFileSomeHow(filename);
        HttpRuntime.Cache.Insert(
            filename ,
            a, 
            null,
            System.Web.Caching.Cache.NoAbsoluteExpiration,
            new TimeSpan(0, 0, 0,10,0,0),
            CacheItemPriority.Default,
            new CacheItemRemovedCallback(DeleteFile));
        return a;
    }
    public void DeleteFile(String key, object value,
        CacheItemRemovedReason removedReason)
    {
        File.Delete(key);
    }
