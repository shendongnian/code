    public static string SafeGetString(this IDataRecord reader, int colIndex)
    {
        if (((colIndex >= 0) && (colIndex < reader.FieldCount)) &&
             !reader.IsDBNull(colIndex))
        {
            return reader.GetString(colIndex);
        }
        return string.Empty;
    }
