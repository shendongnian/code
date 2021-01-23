     using (con = new SqlConnection(Properties.Settings.Default.Connection))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = Properties.Settings.Default.Sqlqry;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            MessageBox.Show(dr[0].ToString());
                        }
                    }
    
                }
