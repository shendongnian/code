    if (c.ConnectionString.Contains("metadata"))
    {
        connection = new EntityConnection(c.ConnectionString);
    }
    else
    {
        connection = new SqlConnection(c.ConnectionString);
    }
    using (connection)
    {
        // same as before.
    }
