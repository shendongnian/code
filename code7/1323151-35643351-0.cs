    public static int ExecSqlNonQuery(string storedProcName, List<SqlParameter> listSqlParams)
        {
            SqlConnection Conn = new SqlConnection("YourConnectionString");
            SqlCommand cmd = new SqlCommand();
            try
            {
                getSqlPara(listSqlParams, cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conn;
                Conn.Open();
                cmd.CommandText = storedProcName;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                    Conn.Dispose();
                }
                cmd.Dispose();
            }
            //return 0;
        }
