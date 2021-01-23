	try
	{
		string connectionString = "Server=your.ip.address;Port=3306;database=YOUR_DATA_BASE;User Id=root;Password=password;charset=utf8";
		MySqlConnection  sqlconn = new MySqlConnection(connectionString);
		sqlconn.Open();
		string queryString = "select count(0) from ACCOUNT";
		MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
		String result = sqlcmd.ExecuteScalar().ToString();
		// do something  with the results
		sqlconn.Close();
	} catch (Exception ex)
	{
		Console.WriteLine (ex.Message);
	}
