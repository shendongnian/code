    public void nonquery(string sql, Dictionary<string, object> parameters, CommandType type = CommandType.Text)
    {
        using (var cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Key, x.Value)));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    ...
    var parameters = new Dictionary<string, object>(2)
    {
        { "@Username", username },
        { "@Password", password }
    };
    nonquery("InsertUser", parameters, CommandType.StoredProcedure);
