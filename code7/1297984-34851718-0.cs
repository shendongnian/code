    internal DataTable Retrieve()
    {
        var sql = "CALL STOREDPROC1()";  // THIS IS THE SYNTHAX
        DataSet dataset = new DataSet();
        OdbcCommand command = new OdbcCommand(sql);
        command.Connection = _libraryConnection.Connection;
        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 0;  // OPTIONAL
        OdbcDataAdapter adapter = new OdbcDataAdapter(command);
        lock (_anyObj)
        {
            _libraryConnection.OpenConnection();
            adapter.Fill(dataset);                
            _libraryConnection.CloseConnection();
        }
        return dataset.Tables[0];
