    var cmd = new OracleCommand
    {
    Connection = connweb,
    CommandText = "begin " +
    ":ret_val:= SYS.diutil.bool_to_int(tk_ccc.GETSTATUS(:p_param1,:p_param2,:p_param3)); " +
    " end; ",
    CommandType = CommandType.Text
    };
    var returnVal = new OracleParameter("ret_val", OracleDbType.Int32,1);
    returnval.Direction=ParameterDirection.ReturnValue;
    cmd.Parameters.Add(returnVal);
    var p_param1 = new OracleParameter("p_param1", OracleDbType.Varchar2, 20);
    p_param1.Direction=ParameterDirection.Input;
    p_param1.Value = "1649983" ;
    cmd.Parameters.Add(p_param1);
	var p_param2 = new OracleParameter("p_param2", OracleDbType.Varchar2, 20);
    p_param2.Direction=ParameterDirection.Input;
    p_param2.Value = "1" ;
    cmd.Parameters.Add(p_param2);
	var p_param3 = new OracleParameter("p_param3", OracleDbType.Varchar2, 200);
    p_param3.Direction=ParameterDirection.Output;
    cmd.Parameters.Add(p_param3);
	var ret = cmd.ExecuteNonQuery();
