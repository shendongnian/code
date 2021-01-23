    try
    {
    	string query = @"SELECT * FROM Registration WHERE Email=@Email 
                                                            and Password=@Password";
    	SqlConnection con = new SqlConnection(connectstr);
    	SqlCommand cmd = new SqlCommand(query, con);
    	cmd.Parameters.AddWithValue("@Email",txtEmail.Text.Trim());
    	cmd.Parameters.AddWithValue("@Password",EncryptedPassword);
    	con.Open();
    	var Results = (int)cmd.ExecuteScalar();
    	//string sqlRead = cmd.ExecuteReader().ToString();
    	if (Results > 0)
    	{
    	    SessionSelection();
    	    txtEmail.Text = "";
    	    txtPassword.Text = "";
    	    Response.Redirect("~/Home.aspx");
    	}
    	else
    	{
    	    Response.Write("Incorrect UserName/Password");
    	}
    	con.Close();
    }
                       
                       
