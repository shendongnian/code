    enter code here
     SqlConnection con = new SqlConnection(
                
     WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
     SqlCommand cmd = new SqlCommand("select * from Accounts_Data where 
     UserName=@username and Password=@password", con);
            cmd.Parameters.AddWithValue("@username", txt_username.Text);
            cmd.Parameters.AddWithValue("@password", txt_userPassword.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Default.aspx");
            }
 
