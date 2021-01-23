    using (connection)
    {
        Int32 id = 1;
        OracleCommand cmd = new OracleCommand("TESTP", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("tempID", OracleDbType.Int32, ParameterDirection.Input).Value = id;
        cmd.Parameters.Add("tempName", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("tempLName", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        string FName = cmd.Parameters["tempName"].Value.ToString();
        string LName = cmd.Parameters["tempLName"].Value.ToString();
    }
