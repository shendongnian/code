    public Task<bool> Insert<T>(T entity) where T : IBaseEntity
    {
       return _redisClient.StringIncrementAsync(CacheProcessPatterns.MakeItemCounter(entity.GetType().Name))
            .ContinueWith(entityCounter =>
            {
    
                if (entity.Id == 0)
                {
                    entity.Id = ((int)GetLastId<T>().Result);
                }
    
            })
            // Explicitly specify task type to be bool
            .ContinueWith<bool>(_ =>
            {
                _redisClient.StringSetAsync(CacheProcessPatterns.MakeLastId(entity.GetType().Name), entity.Id).ContinueWith(status =>
                {
    
                    string itemRedisKey = CacheProcessPatterns.MakeItemById(entity.GetType().Name, entity.Id);
                  _redisClient.StringSetAsync(itemRedisKey, JsonSerializer.SerializeToString<T>(entity)).ContinueWith( setStatus =>
                  {
                        if (setStatus.Result)
                        {
                            ITransaction tran = _redisClient.CreateTransaction();
                            tran.StringSetAsync(CacheProcessPatterns.MakeIdByKey(entity.GetType().Name, entity.Id), entity.Key.ToString());
                            tran.StringSetAsync(CacheProcessPatterns.MakeKeyById(entity.GetType().Name, entity.Key.ToString()), entity.Id);
                            tran.SetAddAsync(CacheProcessPatterns.MakeItemKeysByType(entity.GetType().Name), entity.Id);
                            return tran.ExecuteAsync();
                        }
                        else
                        {
                            _redisClient.StringDecrementAsync(CacheProcessPatterns.MakeItemCounter(entity.GetType().Name));
                        }
    
                        return setStatus;
    
                  });
    
                });
    
                return true;  // since this is a Task<bool> we need a bool return value
