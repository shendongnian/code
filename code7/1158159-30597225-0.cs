    using (OracleCommand cmd = new OracleCommand())
    {
    
        cmd.Connection = cn;
        cmd.CommandText = "DOTNET.SYSTEM_CRUD.BEGIN_TRANSACTION";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.BindByName = true;
    
        cmd.Parameters.Add(new OracleParameter("p_user_id", OracleDbType.Decimal, 4720, ParameterDirection.Input));
        cmd.Parameters.Add(new OracleParameter("p_commt", OracleDbType.Varchar2, "TEST", ParameterDirection.Input));
    
        cmd.ExecuteNonQuery();
    }
