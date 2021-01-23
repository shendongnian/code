    // your controller field
    private readonly MemoryCache _dbDataCache = MemoryCache.Default;
    // string key for your cached data
    private const string DbDataCacheSalesCountKey = "DbDataCacheSalesCountKey";
    public List<DataRow> SalesCount()
    {
        if(_dbDataCache.Contans(DbDataCacheSalesCountKey))
            return _dbDataCache[DbDataCacheSalesCountKey] as List<DataRow>;
 
        string str_salesClass = adding session value here;  
        var lstSales = SalesRepository.SalesCount(SessionValue);
        // save cache only for 10 minutes
        var cip = new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(10)) };
        _dbDataCache.Set(DbDataCacheSalesCountKey, lstSales, cip);
        return lstSales;
    }
