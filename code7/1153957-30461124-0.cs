    public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, dynamic Parameters)
    {
      IEnumerable<T> results = Enumerable.Empty<T>();
      using (var database = new SqlConnection("[ConnectionString]"))
      {
        database.Open();
        results = await database.QueryAsync<T>(sql, Parameters);                        
      }
      return results;
    }
