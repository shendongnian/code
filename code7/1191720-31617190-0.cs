    protected void LoginButton_Click(object sender, EventArgs e)
    {
        // set up your connection string and query as strings
        string connectionString = "Data Source=AA-PC\\SQLSERVER2012;Initial Catalog=oncf;Integrated Security=True";
        string query = "SELECT acc_type FROM dbo.Account WHERE acc_username = @username and acc_password = @password;"
    
        // set up your connection and command in "using" blocks
        using (SqlConnection con = new SqlConnection(connectionString))
        using (SqlCommand cmd2 = new SqlCommand(query, con))
        {
            // define and set parameters
            cmd2.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = TextBox1.Text);
            cmd2.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = TextBox2.Text);
    
            // open connection, execute command, close connection
            con.Open();
            
            object result = cmd.ExecuteScalar();
            
            con.Close();
             
            // if nothing was returned -> user/password are not valid
            if (result == null) {
                Label2.Visible = true;
            }
            else  
            {
                string accountType = result.ToString();
           
                if (accountType == "LandAsset")
                {
                     Response.Redirect("ManageLines.aspx");
                }
                else
                {
                     Response.Redirect("MainAdmin.aspx");
                }
            }
        }
    }
