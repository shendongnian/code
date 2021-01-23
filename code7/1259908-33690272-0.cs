    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        // check what user category was selected and login to appropriate page
        if (DropDownListUserType.SelectedIndex == 1)
        {
            // define connection string and SQL query as strings
            string connectionString = ConfigurationManager.ConnectionStrings["Web_FussConnectionString"].ConnectionString;
            string query = "SELECT Team_ID FROM dbo.Team_User WHERE Email = @username AND Password_1 = @password";
            
            // set up SqlConnection and SqlCommand in "using" blocks
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // define and fill parameters - DO NOT use .AddWithValue!
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = UserName.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = Password.Text;
      
                // open connection, execute scalar, close connection
                con.Open();
    
                object result = cmd.ExecuteScalar();
                
                // if we got back a result ....
                if(result != null)
                {
                    int teamID = Convert.ToInt32(result.ToString());
                    
                    Session["Team_ID"] = teamID;
                    Response.Redirect("AddPlayer.aspx");
                }
            }
        }
    }
