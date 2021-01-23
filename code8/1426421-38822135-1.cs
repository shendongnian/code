	private static void CreateTable(int year)
	{
		using (var connection = new SqlConnection("Data Source=11.22.33.44;"
			+ "Initial Catalog=database_abc;"
			+ "User id=userid;"
			+ "Password=password;"))
		{
			connection.Open();
			var command = new SqlCommand("CREATE TABLE [shipname(" + year + ")] ("
				+ "TagRef VARCHAR(10), "
				+ string.Join(", ", Enumerable.Range(year, 31).Select(t => "[" + t + "] INT"))
				+ ")", connection);
			command.ExecuteNonQuery();
		}
	}
