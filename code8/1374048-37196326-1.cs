    public ListResultOutput<T> GetCache<T>(string cacheKey, Func<T,object> selector)
    {
    	var cache = RedisConnectorHelper.Connection.GetDatabase();
    	var values = JsonConvert.DeserializeObject<List<T>>(cache.StringGet(cacheKey));
    	return values != null ? new ListResultOutput<T>(values.OrderBy(selector).ToList()) : null;
    }
