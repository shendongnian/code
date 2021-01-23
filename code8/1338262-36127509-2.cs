    DataTable dt = new DataTable();
    OracleCommand command = new OracleCommand(@"BEGIN :RETURNCURSOR := APITT_tbl_request(:prefix_db); END;");
    command.CommandType = CommandType.Text;
    command.Parameters.Add("RETURNCURSOR", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
    command.Parameters.Add("prefix_db", OracleDbType.Varchar2, ParameterDirection.Input).Value = prefix_db;
    OracleDataAdapter da = new OracleDataAdapter(command);
    da.Fill(dt);
