    using (OracleConnection con = new OracleConnection(AppConn.Connection))
    {
        using (OracleCommand cmd = con.CreateCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandText = "P_Pkg.found";
            OracleParameter p_id = new OracleParameter();
            p_id.ParameterName = "p_id";
            p_id.OracleDbType = OracleDbType.Int64;
            p_id.Direction = ParameterDirection.Input;
            p_id.Value = requestHeader.approval_id;
            OracleParameter retVal = new OracleParameter();
            retVal.ParameterName = "ReturnValue";
            retVal.OracleDbType = OracleDbType.Varchar2; // Whatever the type the SP returns
            retVal.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(p_id);
            cmd.Parameters.Add(retVal);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                string found = cmd.Parameters["ReturnValue"].Value.ToString();
            }
            catch (Exception ex)
            {
    
            }
            finally
            {
                con.Close();
            }
        }
    }
