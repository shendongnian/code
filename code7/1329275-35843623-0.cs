    using (OracleCommand sc = new OracleCommand("udsp_Check_Gen_Setting", PubFun.ConOrcl))
    {
        sc.CommandType = CommandType.StoredProcedure;
        sc.Parameters.Add("retval", OracleDbType.Int16,10, ParameterDirection.ReturnValue);
        sc.Parameters.Add("p_SysName", OracleDbType.NVarchar2).Value = p_SysName.Trim();
        sc.Parameters.Add("p_UsrName", OracleDbType.NVarchar2).Value = p_UsrName.Trim();
        
        sc.ExecuteNonQuery();
        conclose();
        retVal = Convert.ToInt16(sc.Parameters["retval"].Value);
    }
    return retVal;
