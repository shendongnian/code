    public void Insert(string table, Dictionary<string, object> values)
    {
        string query = "INSERT INTO " + table + " (";
        foreach (KeyValuePair<string, object> pair in values)
            query += "[" + pair.Key + "],";
        query = query.Substring(0, query.Length - 1) + ")";
        query += "VALUES (";
        foreach (KeyValuePair<string, object> pair in values)
            query += ParamName(pair.Key) + ",";
        query = query.Substring(0, query.Length - 1) + ")";
        using (var sqlConnection = new SqlConnection("..."))
        {
            sqlConnection.Open();
            using (SqlCommand command = sqlConnection.CreateCommand())
            {
                command.CommandText = query;
                foreach (KeyValuePair<string, object> pair in values)
                {
                    command.Parameters.AddWithValue(ParamName(pair.Key), pair.Value);
                }
                // execute command
                command.ExecuteNonQuery();
            }
        }
    }
    private string ParamName(string input)
    {
        return "@_" + input.Replace(" ", "_");
    }
