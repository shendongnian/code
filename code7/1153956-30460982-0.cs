    public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql)
    {
        using (var database = new SqlConnection("[ConnectionString]"))
        {
            database.Open();
            return await database.QueryAsync<T>(sql);                        
        }
    }
