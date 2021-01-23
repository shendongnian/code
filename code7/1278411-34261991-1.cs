	SqlConnection Conn = new SqlConnection("Data Source=SUMIT;Initial Catalog=Project;Integrated Security=True"); 
	SqlCommand Comm1 = new SqlCommand("Select * from id WHERE ID = " + BtnCount  , Conn); 
	Conn.Open(); 
	SqlDataReader DR1 = Comm1.ExecuteReader();
	while(DR1.Read()) 
	{
		ListData.Add(DR1.GetValue(0).ToString());
	}
	Conn.Close();
