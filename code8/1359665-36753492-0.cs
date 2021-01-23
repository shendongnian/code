    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
    	var conStr = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\Donald\Documents\Visual Studio 2013\Projects\DesktopApplication\DesktopApplication\Student_CB.mdf ;Integrated Security=True";
    	using(SqlConnection conn = new SqlConnection(conStr))
    	{
    		conn.Open();
    		string sql = "Select count(*) from Student Where Student_Username=@username";
    		SqlCommand cmd = new SqlCommand(sql, conn);
    		cmd.Parameters.AddWithValue("@username", usernameTxt.Text);
    		int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
    
    		if (temp == 1)
    		{
    			string checkPassword = "Select Student_Password from Student Where Student_Username=@username";
    			SqlCommand cmd2 = new SqlCommand(checkPassword, conn);
    			cmd.Parameters.AddWithValue("@username", usernameTxt.Text);
    			string password = cmd2.ExecuteScalar().ToString();
    			if (password == passwordTxt.Text)
    			{
    				Session["New"] = usernameTxt.Text;
    				Response.Write("corret");
    			}
    			else
    			{
    				Response.Write("incorrect");
    			}
    		}
    		else
    		{
    			Response.Write("username is incorret");
    		}
    	}
    }
