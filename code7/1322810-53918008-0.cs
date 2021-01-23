    public static class DbContextCommandExtensions
    {
      public static async Task<int> ExecuteNonQueryAsync(this DbContext context, string rawSql,
        params object[] parameters)
      {
        var conn = context.Database.GetDbConnection();
        using (var command = conn.CreateCommand())
        {
          command.CommandText = rawSql;
          if (parameters != null)
            foreach (var p in parameters)
              command.Parameters.Add(p);
          await conn.OpenAsync();
          return await command.ExecuteNonQueryAsync();
        }
      }
    
      public static async Task<T> ExecuteScalarAsync<T>(this DbContext context, string rawSql,
        params object[] parameters)
      {
        var conn = context.Database.GetDbConnection();
        using (var command = conn.CreateCommand())
        {
          command.CommandText = rawSql;
          if (parameters != null)
            foreach (var p in parameters)
              command.Parameters.Add(p);
          await conn.OpenAsync();
          return (T)await command.ExecuteScalarAsync();
        }
      }
    }
