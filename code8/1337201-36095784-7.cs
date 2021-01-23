    public static void SetContextCache(IControllerContextClonable context, string cacheKey = "SiteContext" )
    {
        CacheList<IControllerContextClonable>.RemoveCache( cacheKey );
        CacheList<IControllerContextClonable>.Add( new List<IControllerContextClonable> { context} );
        CacheList<IControllerContextClonable>.CacheIt( cacheKey );
    }
