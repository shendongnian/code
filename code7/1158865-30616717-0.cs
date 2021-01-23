    public static string GetText(this DataRow row, string columnName)
    {
        if (row.IsNull(columnName))
            return string.Empty;
        return row[columnName] as string ?? string.Empty;
    }
