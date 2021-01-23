    private async Task<IList<T>> QueryAsync<T, TSecond>(string storedProcedureName, Func<T, TSecond, T> map, string splitOn, OracleDynamicParameters parameters = null, ... other 3 params)
    {
    
        //big switch here based on what are null or not
        var models = await this._connection.QueryAsync<...>(...);
    
        // Return our list
        return models.ToList();
    }
