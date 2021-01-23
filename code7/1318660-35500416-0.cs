    using(DbConnection connection = c.ConnectionString.Contains("metadata") ? 
      new EntityConnection(c.ConnectionString) : new SqlConnection(c.ConnectionString))
    {
        try
        {
            connection.Open();
            isWorking = true;
            connection.Close();
        }
        catch (Exception e) //make this more generic
        {
            //Do something
        }
    }
