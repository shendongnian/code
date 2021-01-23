    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
             SqlCommand cmd = new SqlCommand("select * from 'user_insert' where username = @username and password = @password,con");
                  cmd.Parameters.AddWithValue("@username", TextBox1.Text);
                  cmd.Parameters.AddWithValue("@password", TextBox2.Text);
              SqlDataAdapter da = new SqlDataAdapter(cmd);
              DataTable dt = new DataTable();
              dt.Load(cmd.ExecuteReader());
              da.Fill(dt);
