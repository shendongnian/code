    public ListResultOutput<T> GetCache<T>(string cacheKey) where T: IDto
    {
        var cache = RedisConnectorHelper.Connection.GetDatabase();
        var values = JsonConvert.DeserializeObject<List<T>>(cache.StringGet(cacheKey));
        return values != null ? new ListResultOutput<T>(values.ToList().OrderBy(o=>o.Name)) : null;
    }
