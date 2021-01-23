		using(SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
		{
			SqlCommand cmd = new SqlCommand("select * from Users where username like @username and password = @password;");
			cmd.Parameters.AddWithValue("@username", username);
			cmd.Parameters.AddWithValue("@password", password);
			cmd.Connection = con;
			con.Open();
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(ds);
			con.Close();
			bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
			
			if (loginSuccessful)
			{
				Console.WriteLine("Success!");
			} else {
				Console.WriteLine("Invalid username or password");
			}
		}
