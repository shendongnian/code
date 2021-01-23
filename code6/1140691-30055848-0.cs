    instance.Id = MCCDBUtility.GetValue<int>(dr, "columnName")
    public T GetValue<T>(IDataReader reader, string columnName)
    {
         object value GetValue(reader, columnName);
         return Convert.ChangeType(value, typeof(T));
    }
    private object GetValue(IDataReader reader, string columnName)
    {
        var schmema = reader.GetSchemaTable();
        var dbType = typeof(object);
        foreach(DataRowView row in schema.DefaultView)
            if (row["columnName"].ToString().Equals(columnName, StringComparer.OrdinalIgnoreCase))
                return row["ColumnType"];
        if (dbType.Equals(typeof(int))
            return GetInt(reader, columnName)
        ... // you get the point
        else
            return GetObject(reader, columnName);
    }
