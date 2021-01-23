        protected void Button3_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tablename where +" + TextBox2.Text + " condition"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        foreach (DataRow dtRow in dt.Rows)
                        {
                            // On all tables' columns  
                            foreach (DataRow row in dt.Rows)
                            {
                                TextBox1.Text = row["FirstName"].ToString();  
                                TextBox2.Text = row["lastName"].ToString();  
                                //......
                                //                      etc  
                            }
                        }
                    }
                }
            }
        }
