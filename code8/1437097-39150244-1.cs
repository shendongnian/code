    public virtual async Task<IDataReader> GetReaderAsync(string StoredProcedureName, params object[] Parameters)
    {
        InitDatabase();
        var connection = new SqlConnection(databaseControllers[connectionStringName].ConnectionString);
        var cmd = new SqlCommand
        {
            Connection = connection,
            CommandType = CommandType.StoredProcedure,
            CommandText = dbPrefixName + StoredProcedureName
        };
        await connection.OpenAsync();
        SqlCommandBuilder.DeriveParameters(cmd);
        if (cmd.Parameters.Count - 1 > Parameters.Count())
            throw new InvalidOperationException("The number of parameters provided does not match the number of parameters in the stored procedure. There are " + Parameters.Count().ToString() + " parameters provided, however the stored procedure requires " + cmd.Parameters.Count.ToString() + " parameters.");
        for (int i = 0; i < Parameters.Count(); i++)
        {
            cmd.Parameters[i + 1].Value = Parameters[i];
        }
        var reader = await cmd.ExecuteReaderAsync();
        return reader;
    }
