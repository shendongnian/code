    public static string SafeGetString(this IDataRecord reader, int colIndex)
    {
        if (colIndex >= 0 && colIndex < reader.FieldCount)
        {
            return Convert.ToString(reader[colIndex]);
        }
        else
        {
            return "";
        }
    }
