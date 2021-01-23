    using (OracleConnection cn = new OracleConnection(connectionString))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                         
                        cmd.Connection = cn;
                        cmd.CommandText = "SYSTEM_CRUD.BEGIN_TRANSACTION";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.BindByName = true;
    
    
                        cmd.Parameters.Add("p_user_id", OracleDbType.Decimal, ParameterDirection.Input).Value = 4720;
                        cmd.Parameters.Add("p_commt", OracleDbType.Varchar2, ParameterDirection.Input).Value = "TEST";
                        cmd.Parameters.Add("return_value", OracleDbType.Decimal).Direction = ParameterDirection.ReturnValue;
    
                        cmd.ExecuteNonQuery();
