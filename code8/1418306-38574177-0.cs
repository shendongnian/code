    using(OracleCommand cmd = new OracleCommand("SPROC_ONLINE", TheConnection))
	{
		using(OracleDataReader reader = new OracleDataReader())
		{
			while(reader.Read())
			{
				// Extract the values
				var a = reader["Year"];
				var b = reader["Name"];
				var c = reader["ID"];
				... etc ...
			}
		}
	}
