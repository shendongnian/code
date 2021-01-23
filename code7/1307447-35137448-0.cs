    public async Task<int> Write2Log()
    {
      ExceptionDispatchInfo capturedException = null;
      using (SqlConnection conn = new SqlConnection(connectionString))
      {                   
          using (SqlCommand cmd = new SqlCommand(commandText, conn))
          {
    
              try
    {
             await cmd.Connection.OpenAsync();
             return await cmd.ExecuteNonQueryAsync();
    }
               catch (Exception ex)
                 {
                   capturedException=ExceptionDispatchInfo(ex);
                 
                 }
    
                 // unreachable unless placed inside `finally` block
                if (capturedException != null)
                  {
                       capturedException.Throw();
                  }
    
          }
    
    
      }
       return -1;
    }
