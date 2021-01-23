    using(var con = new MysqlConnection{ ConnectionString = "your connection string " })
    {
	    using(var command = new MysqlCommand{ Connection = con })
	    {
		   con.Open();
		
		   command.CommandText = @"SELECT level FROM userTable WHERE username=@username, password=@password";
		   command.AddWithValue("@username", txtusername.Text);
		   command.AddWithValue("@password", txtpassword.Text);
		   var strLevel = myCommand.ExecuteScalar();
		   if(strLevel == DBNULL.Value || strLevel == Null)
		   {
			  MessageBox.Show("Invalid username or password");
			  return;
		   }
		   else
		   {
			  MessageBox.Show("Successfully login");
			  hide(); // hide this form and show another form
		   }
		
	}
}
