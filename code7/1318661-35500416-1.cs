    using(DbConnection connection = c.ConnectionString.Contains("metadata") ? 
      new EntityConnection(c.ConnectionString) as DbConnection: new SqlConnection(c.ConnectionString) as DbConnection)
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
