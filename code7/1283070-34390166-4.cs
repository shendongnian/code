	EmployeeEntity record = new EmployeeEntity
	{
		name = txtname.Text,
		currentdate = Convert.ToDateTime(txtcurrdate.Text),
		modifieddate = Convert.ToDateTime(txtmodifieddate.Text)
	};
	EmployeeController add = new EmployeeController();
	add.Add(record);
	Label1.Visible = true;
	Label1.Text = "Your Empl ID is " + FetchLastID();
	Clear();
	public string FetchLastID()
	{
		SqlConnection con = new SqlConnection(ConnString);
		con.Open();
		IDbCommand Cmd = con.CreateCommand();
		Cmd.CommandText = "Select max(EmpId) from Employee";
		IDataReader LastID = Cmd.ExecuteReader();
		LastID.Read();
		return LastID[0].ToString() ;
	}
