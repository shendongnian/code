     SqlCommand sqlcmd = new SqlCommand();
                    using (SqlConnection sqlconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconnectionstringFromConfigFile"].ConnectionString))
                    {
                        sqlcmd.Connection = sqlconn;
                        sqlconn.Open();
                        sqlcmd.CommandType = CommandType.Text;
                        sqlcmd.CommandText = "sql statement";
                        sqlcmd.ExecuteNonQuery();
                    }
