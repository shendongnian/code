       private static DataTable GetData(string query)
            {
                DataTable dt = new DataTable();
                string constr = "Data Source=AZEEM\\SQLEXPRESS; Initial Catalog=kics;User ID=sa;Password=123";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
        
                        }
                    }
                    return dt;
                }
            }
