	string query = "Select Content from dbo.MyTable";
	using(SqlConnection connection = new SqlConnection(/*your connection string here*/))
	using(SqlCommand command = new SqlCommand(query, connection))
	{
		connection.Open();
		using (SqlDataReader d = command.ExecuteReader())
		{
			if (d.Read())
	        {
			    byte[] byteArray = (byte[])d["Content"];
			}
		}
	}
