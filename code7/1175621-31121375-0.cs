	var customers = new List<Tuple<int, string>>(); // the list of ID, Name
	using (var con = new SqlConnection("your connection string"))
	{
		using(SqlCommand cmd = new SqlCommand("select ID, Name from Customer", con))
		{
			con.Open();       
			using(SqlDataReader reader = cmd.ExecuteReader())
			{
				while (reader.Read())
				{
					customers.Add(new Tuple<int, string>(
						(int)reader["ID"], reader["Name"].ToString()));
				}
			}
		}
	}
	// Store customers to file
