    reference using Oracle.DataAccess.Client;
    public DataSet ListaClientes()
        {
            DataSet ds = new DataSet();
            try
            {
                OracleConnection conexion = Conexion.GetConnection2();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    OracleCommand  cmd = new OracleCommand();
                    cmd.Connection = conexion;
                    cmd.CommandText = "ListadoClientes";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("resul", OracleDbType.RefCursor).Direction = ParameterDirection.Output;                    
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    OracleDataAdapter  da = new OracleDataAdapter(cmd);                    
                    da.Fill(ds);
                }
                return ds;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
