    using (SqlConnection con = new SqlConnection(connectionString))
	{
	    using (SqlCommand command = new SqlCommand("SELECT TOP 100 * FROM SomeTable", con))
	    using (SqlDataReader reader = command.ExecuteReader())
	    {
		while (reader.Read())
		{
		    Console.WriteLine("{0} {1} {2}",
			reader.GetString(0), reader.GetString(1), reader.GetString(2));
		}
	    }
     }
