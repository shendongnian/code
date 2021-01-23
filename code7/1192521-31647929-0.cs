	using (connection)
	{
		connection.Open();
		var buffer1 = new List<string>();
		using (SqlDataReader reader1 = cmd1.ExecuteReader())
		{
			while (reader1.Read())
				buffer1.Add(reader1["AccountID"].ToString());
		}
		for (int i = 0; i < buffer1.Count; i++)
		{
			cmd2.Parameters.AddWithValue("@Referrer", buffer1[i]);
			var buffer2 = new List<string>();
			using (SqlDataReader reader2 = cmd2.ExecuteReader())
			{
				while (reader2.Read())
					buffer2.Add(reader2["AccountID"].ToString());
			}
			for (int j = 0; j < buffer2.Count; j++)
			{
				// Keep nesting this further. You could of course write a recursive function
			}
		}
	}
