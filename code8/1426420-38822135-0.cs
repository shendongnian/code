	private static void CreateTable(int year)
	{
		using (var connection = new SqlConnection("Data Source=10.112.125.22;"
			+ "Initial Catalog=ifos;"
			+ "User id=sa;"
			+ "Password=123456;"))
		{
			connection.Open();
			var command = new SqlCommand("CREATE TABLE [shipname(" + year + ")] ("
				+ "TagRef VARCHAR(10), "
				+ string.Join(", ", Enumerable.Range(year, 31).Select(t => "[" + t + "] INT"))
				+ ")", connection);
			command.ExecuteNonQuery();
		}
	}
