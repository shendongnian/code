	protected void SubmitBtn_Click(object sender, EventArgs e)
	{
		var conStr = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\Donald\Documents\Visual Studio 2013\Projects\DesktopApplication\DesktopApplication\Student_CB.mdf ;Integrated Security=True";
		
		bool userExists = false;
		using(SqlConnection conn = new SqlConnection(conStr))
		{
			conn.Open();
			string sql = "Select count(*) from Student Where Student_Username=@username";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@username", usernameTxt.Text);
			var reader = cmd.ExecuteReader();
			userExists = reader.Read(); // if there is 1 row there is a record which means there was a user by that name
		}
		
		if (userExists)
		{
			string password;
			using(SqlConnection conn = new SqlConnection(conStr))
			{
				conn.Open();
				string checkPassword = "Select Student_Password from Student Where Student_Username=@username";
				SqlCommand cmd2 = new SqlCommand(checkPassword, conn);
				cmd.Parameters.AddWithValue("@username", usernameTxt.Text);
				
				using(var reader = cmd.ExecuteReader())
				{
					reader.Read(); // read 1st row
					password = reader.GetString(0); // get string in position 0
				}
			}
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
