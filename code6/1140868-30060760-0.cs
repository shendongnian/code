    public string GetValue(string key) 
    {
        RedisValue value = _cacheRepo.GetString(key);
        // You might also use !value.IsNullOrEmpty
        if (value.HasValue)
        {
            return value;
        }
        else 
        {
            //Get value from SQL, put it into Redis, then return it
        }
    }
