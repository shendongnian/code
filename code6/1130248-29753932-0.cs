            string cmdStr1 = "SELECT * FROM [Table1];";
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn1 = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd1 = new SqlCommand(cmdStr1, conn1))
                    {
                        conn1.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                        {
                            da.Fill(ds);
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                        }
                        conn1.Close();
                        cmd1.Dispose();
                        conn1.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Label2.Text = ex.ToString();
         
