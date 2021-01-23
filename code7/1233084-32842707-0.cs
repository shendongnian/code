                String connStr = GetConnectionString());
                String cmdStr = "SQLStoredProcedure";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
                        {
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            cmd.Dispose();
                            conn.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    TextBox1.Text = ex.Message;
                }
        DataSet ds = new DataSet();
        using (SqlDataAdapter Dap_Proj = new SqlDataAdapter)
        {
   ...
        }
