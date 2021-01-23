    public static IEnumerable<Dictionary<string, object>> ToEnumerable(this IDataReader reader)
    {
        while (reader.Read())
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            for (int column = 0; column < reader.FieldCount; column++)
                result.Add(reader.GetName(column), reader.GetValue(column));
            yield return result;
        }
    } 
