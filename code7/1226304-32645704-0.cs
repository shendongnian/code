      try
      {
        singletonConnection = new SqlConnection("Data Source.....");
      }
      catch (SqlException)
      {
        throw;
      }
      finally 
      {
        singletonConnection.Close();
      }
