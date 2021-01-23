    SqlConnection conn = new SqlConnection();
	StringBuilder sb=new StringBuilder();
	sb.Append("Data Source = 123.456.789.012;");
	sb.Append("Initial Catalog = DiscoverThePlanet;");
	sb.Append("User ID = TestUser;");
	sb.Append("Password = Test;");
	conn.ConnectionString =sb.ToString();
	try
	{
		conn.Open();
		MessageBox.Show("Connection Established!");
		conn.Close();
	}
	catch (Exception ex)
	{
		MessageBox.Show("Can not open Connection!");
	}
