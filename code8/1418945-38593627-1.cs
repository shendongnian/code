    OracleParameterCollection dbParams = dbCommand.Parameters;
    dbParams.Add("p_return_val", OracleDbType.Varchar2, 500, null, ParameterDirection.ReturnValue);
    dbParams.Parameters["p_return_val"].DbType = DbType.String; // Maybe this line is not required at Oracle.ManagedDataAccess. However, you must use it for Oracle.DataAccess
    dbParams.Add("p_id", OracleDbType.Varchar2, "123", ParameterDirection.Input); 
    string Function_query = "BEGIN :p_return_val := PKG_TEST.return_test(:p_id); END;";
    cmd = new OracleCommand(Function_query , dbConnection);     
    cmd.CommandType = CommandType.Text
    cmd.Parameters.Add(dbParams);
    cmd.ExecuteNonQuery();
    retval = cmd.Parameters["p_return_val"].Value;
