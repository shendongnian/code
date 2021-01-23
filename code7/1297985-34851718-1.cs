    internal DataTable Retrieve()
    {
        var sql = "STOREDPROC1()";  // THIS IS THE SYNTHAX
        OleDbDataAdapter adapter= new OleDbDataAdapter();
        DataTable dt = new DataTable();
        ADODB.Command command = new ADODB.Command();
        ADODB.Recordset rs = new ADODB.Recordset();
        command.ActiveConnection = _libraryConnection.Connection;
        command.CommandType = ADODB.CommandTypeEnum.adCmdStoredProc;
        command.CommandText = sql;
        command.CommandTimeout = 0;  // OPTIONAL
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseServer;
        lock (_anyObj)
        {
            rs.Source = command;
            rs.Open();
            adapter.Fill(dt, rs);
            rs.Close();
        }       
        return dt;
   }
