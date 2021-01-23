    public async Task<IList<AsyncFileProcessingQueue>> GetAsyncFileProcessingQueue()
    {
       IList<AsyncFileProcessingQueue> result;
       using (IDbConnection conn = new SqlConnection(DataConnectionString))
       {
          conn.Open();
    
          var entities = await conn.QueryAsync<AsyncFileProcessingQueue>
              ("SELECT * FROM YOUR_TABLE");
    
          result = entities.ToList();
       }
       return result;
    }
