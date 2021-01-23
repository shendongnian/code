	//After your logic to add the record to DB
	//Close and Dispose the Connection, Commands and related objects
	SqlConnection con = new SqlConnection(ConnString);
	con.Open();
	IDbCommand Cmd = con.CreateCommand();
	Cmd.CommandText = "Select max(EmpId) from Employee";
	IDataReader LastID = Cmd.ExecuteReader();
	LastID.Read();
	MessageBox.Show("Your Empl ID is " + LastID[0].ToString());
	con.Close();
