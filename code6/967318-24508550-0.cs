    public static T SQLGet<T>(SqlConnection conn, string sql)
    {
        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = conn;
            command.CommandTimeout = 0; // No timeout - set or remove.
            command.CommandText = sql;
            return (T)Convert.ChangeType(Command.ExecuteScalar(), typeof(T));
        }
    }
    
