	string sql = "SELECT ID, Element FROM mybrknElements; ";
	string sql2 = "SELECT ID, Element FROM mybrknElements2;";
	int nWords = 0;
	string connectionString = "Your Connection String";
	
	using (var connection = new SqlConnection(connectionString))
	using (var command = new SqlCommand(sql1, connection))
	{
		connection.Open();
		using (var reader = command.ExecuteReader())
		{
			string sWord = reader.GetString(0);
			string sNum = reader.GetString(1);
			
			using (var connection2 = new SqlConnection(connectionString))
			using (var command2 = new SqlCommand(sql2, connection2))
			{
				connection2.Open();
				using (var reader2 = command2.ExecuteReader())
				{
					string sWord2 = reader2.GetString(0);
					string sNum2 = reader2.GetString(1);
					
					if (Equals(sWord1,sWord2))
					{
						nWords++;
					}
				}
			}			
		}
	}
	
