	int indexyouwant = 1; // Suppose 1 is your Edit Page Tab. 
	Form1 frm = new Form1();
	// SQL 
	if (reader.HasRows)
	{
		if(reader[0]==txtUserName.Text   && reader[1]==txtPassword.Text)
		{
			frm.YourTabControlName.SelectedIndex = indexyouwant;
		}
	}
   
