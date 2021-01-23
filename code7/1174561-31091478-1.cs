	try
	{
		MySqlConnection connection = new MySqlConnection("Server=localhost; database=member; UID=root; Pwd=");
		connection.Open();
		// Using parameters to prevent SQL Injections
		MySqlCommand cmd =
			new MySqlCommand("SELECT * FROM member.member WHERE username=@username AND password=@password ;",
				connection);
		cmd.Parameters.AddWithValue("@username", this.metroTextBox1.Text);
		cmd.Parameters.AddWithValue("@password", this.metroTextBox2.Text);
		var myReader = cmd.ExecuteReader();
		if (myReader.HasRows)
		{
			//Record found
			myReader.Read();
			// Assuming there's always a valid date in your table otherwise
			// an exception will be thrown while trying to convert to a DateTime object
			var expiryDate = myReader.GetDateTime("expirationdate");
			// Use this to show the remaining days on your label
			int remainingDays = (int) (DateTime.Now - expiryDate).TotalDays;
 			string labelCaption = String.Format("You have {0} day(s) left.", remainingDays);
			if (DateTime.Now > expiryDate)
			{
				//Login Expired
			}
			else
			{
				//Login is still valid
				Form2 frm = new Form2();
				frm.username = metroTextBox1.Text;
				frm.Show();
				this.Visible = false;
			}
		}
		else
		{
			//No record found
			MetroMessageBox.Show(this, "Incorrect login credentials. Failed to login!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
	catch (Exception)
	{
		// Do your exception handling
	}
