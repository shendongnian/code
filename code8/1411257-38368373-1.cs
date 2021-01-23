    private string GetSqlSelectFrom<T>(int appVersion) where T : IDataItem
    {
        var sql = typeof(T).GetCustomAttribute<SqlAttribute>();
        if (sql != null)
        {
            return sql.Select;
        }
        throw new Exception("....");
    }
