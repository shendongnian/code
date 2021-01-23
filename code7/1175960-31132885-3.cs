    public static DBEntity Create(String connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString)) //use this instead of IsNullOrEmpty
            return DBEntity();
        else
            return new DBEntity(connectionString); // this one fails
    }
