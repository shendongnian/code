     static string strConnectionString = ConfigurationManager.ConnectionStrings["CustomerDataConnectionString"].ConnectionString;
     using (OracleConnection con = new OracleConnection(strConnectionString))
                {
    try
                        {
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
    
                            }
    
                            using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                            {
                                table = new DataTable();
                                da.Fill(table);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
               }
