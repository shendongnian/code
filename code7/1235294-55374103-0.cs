    public class DwContext : DbContext, IDbModelCacheKeyProvider
    {
        string IDbModelCacheKeyProvider.CacheKey => DwContextSettings.cacheKey;
        ...
    }
