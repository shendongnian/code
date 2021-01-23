    public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, dynamic Parameters = null)
    {
      IEnumerable<T> results;
      using (var database = new SqlConnection("[ConnectionString]"))
      {
        database.Open();
        results = await database.QueryAsync<T>(sql, Parameters);                        
      }
      return results;
    }
