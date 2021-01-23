	SqlConnection Conn = new SqlConnection("Data Source=SUMIT;Initial Catalog=Project;Integrated Security=True"); 
	SqlCommand Comm1 = new SqlCommand("Select * from id WHERE ID = " + BtnCount  , Conn); 
	Conn.Open(); 
	SqlDataReader DR1 = Comm1.ExecuteReader();
	if (DR1.Read()) {
		textBox3.Text = DR1.GetValue(0).ToString();
	}
	Conn.Close();
	BtnCount ++;
	if(BtnCount>30)
	{
		BtnCount = 0;
	}
	
