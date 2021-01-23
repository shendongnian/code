    using Oracle.DataAccess.Client;
    ...
        OracleConnection con = new OracleConnection(connectionString);
        con.Open();
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = con;
        cmd.CommandText = "IS_GEC_AVAILABLE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("result", OracleDbType.Decimal, 0, ParameterDirection.ReturnValue);
        cmd.Parameters.Add("policyNo", OracleDbType.Varchar2, 1, "X", ParameterDirection.Input);
        cmd.Parameters.Add("startDate", OracleDbType.Decimal, 0, ParameterDirection.Input);
        cmd.Parameters.Add("EndDate", OracleDbType.Decimal, 0, ParameterDirection.Input);
        cmd.ExecuteNonQuery();
        Console.WriteLine("result: " + cmd.Parameters[0].Value);
        con.Close();
    
