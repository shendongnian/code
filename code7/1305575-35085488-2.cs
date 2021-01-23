    public static IEnumerable<T> ToEntity<T>(this IDataReader reader) where T : new()
    {
        var properties = typeof(T).GetProperties();
        while (reader.Read())
        {
            var result = new T();
            foreach (var prop in properties)
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i).Replace("_", "").Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var val = reader.GetValue(i) != DBNull.Value ? reader.GetValue(i) : null;
                        prop.SetValue(result, val);
                    }
                }
            }
            yield return result;
        }
    }
