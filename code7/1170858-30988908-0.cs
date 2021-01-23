    public static class DALHelper
    {
        public static DataSet ExecuteProcedure(string procedureName)
        {
            string sqlDBConnection = Utils.GetConnectionString();    
            DataSet ds = new DataSet();
        
            using (SqlConnection sqlConn = new SqlConnection(sqlDBConnection))
            {
                using(SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        sqlConn.Open();
        
                        using (var adapter = new SqlDataAdpter(sqlCmd))
                        {
                            adapter.Fill(ds);
                        }            
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }
            
            return ds;
        }
    }
