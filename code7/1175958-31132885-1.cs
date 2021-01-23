    public static DBEntity Create(String connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
            return DBEntity();
        else
            new DBEntity(connectionString); // this one fails
    }
