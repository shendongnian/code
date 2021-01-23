    public static DataTable GetS<T>(string input)
    {
        if(T is Guid)
        {
            return GetDataTableFromQuery("db.GetS", new object[] { "@source", input});
        }
        else
        {
            return GetDataTableFromQuery("db.GetS", new object[] { "@customer", input]);
        }
    }
