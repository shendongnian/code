                string sql = "select ....";
                string whereToConnect = MABP.GetdomainUrl()=="localhost" ? "ConnectionStringClient" : "ConnectionStringServer";
                string connectionString = ConfigurationManager.ConnectionStrings[whereToConnect].ToString();
                var dt = new DataTable();
    
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var adapter = new SqlDataAdapter(sql, connection))
                    {
                        try
                        {
                            adapter.Fill(dt);
                        }
                        catch
                        { 
                            // Deal with exceprion if you want 
                        }
                    }
                }
    
                return dt;
