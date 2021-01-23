	protected void SubmitBtn_Click(object sender, EventArgs e)
	{
		var conStr = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\Donald\Documents\Visual Studio 2013\Projects\DesktopApplication\DesktopApplication\Student_CB.mdf ;Integrated Security=True";
		
		bool userExists = false;
		string password = null;
		using(SqlConnection conn = new SqlConnection(conStr))
		{
			conn.Open();
			string sql = "Select Student_Password from Student Where Student_Username=@username";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@username", usernameTxt.Text);
			using(var reader = cmd.ExecuteReader())
			{
				if(reader.Read()) // if there is a record there is a user so get the password
				{
					userExists = true;
					password = reader.GetString(0); // get string in position 0
				}
			}
		}
		
		if (userExists)
		{
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
