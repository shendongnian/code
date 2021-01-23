    string ConnectionString = "<Your connection string here>";
    string procedureName = "<your stored procedure name here>";
    string ParamName = "@<Parameter name>"; // NOTE: the '@' is INSIDE the string!
    DataSet ds = new DataSet();
    using (var connection = new SqlConnection(ConnectionString))
    {
        var cmd = new SqlCommand(procedureName, connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(ParamName, SqlDbType.Int).Value = 5;
        using (var adapter = new SqlDataAdapter(cmd))
        { 
            adapter.Fill(ds);
        }
    }
