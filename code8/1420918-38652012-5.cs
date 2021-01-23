    private static string getInsertCommand(string table, List<KeyValuePair<string, string>> values)
    {
        string query = null;
        query += "INSERT INTO " + table + " ( ";
        foreach (var item in values)
        {
            query += item.Key;
            query += ", ";
        }
        query = query.Remove(query.Length - 2, 2);
        query += ") VALUES ( ";
        foreach (var item in values)
        {
            if (item.Key.GetType().Name == "System.Int") // or any other numerics
            {
                query += item.Value;
            }
            else
            {
                query += "'";
                query += item.Value;
                query += "'";
            }
            query += ", ";
        }
        query = query.Remove(query.Length - 2, 2);
        query += ")";
        return query;
    }
