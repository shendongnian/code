    public static Nullable<T> getDBSpecifiedType<T>(string columnName, DataTable table, int index = 0)
    {
        if (getDB<T>(columnName, table, index) != String.Empty)
        return (T)Convert.ChangeType(table.Rows[index][columnName], typeof(T));
        return null;
    }
