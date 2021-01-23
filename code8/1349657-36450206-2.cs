    public List<DataRow> SalesCount()
    {
        var salesCount = _dbDataCache[DbDataCacheSalesCountKey] as List<DataRow>;
        if(salesCount == null)
        {
            string str_salesClass = adding session value here;  
            salesCount = SalesRepository.SalesCount(SessionValue);
            // save cache only for 10 minutes
            var cip = new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(10)) };
            _dbDataCache.Set(DbDataCacheSalesCountKey, salesCount, cip);
        }
        return salesCount;
    }
