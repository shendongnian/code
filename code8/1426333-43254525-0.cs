    using(var connection = new SQLiteConnection(ConnectionString))
    {
       try
       {
          connection.Open();
       }
       catch (Exception e)
       {
          throw new Exception(e.Message);
       }
       finally
       {
          connection.Close();
       }     
    }  
