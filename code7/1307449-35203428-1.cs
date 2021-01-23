    public async Task<int> Write2Log()
    {
      using (var conn = new SqlConnection(connectionString))
      {
        using (var cmd = new SqlCommand(commandText, conn)
        {
          try
          {
            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync();
          }
          catch
          {
            return -1;
          }
        }
      }
    }
