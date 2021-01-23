    if (c.ConnectionString.Contains("metadata"))
    {
        using (var connection = new EntityConnection(c.ConnectionString))
        {
            isWorking = CheckConnection(connection);
        }
    }
    else
    {
        using (var connection = new SqlConnection(c.ConnectionString))
        {
            isWorking = CheckConnection(connection);
        }
    }
