    String show = "Select Posts from userPosts where Username='John';
    using (SqlCommand command = new SqlCommand(show, connection))
	    {
		using (SqlDataReader reader = command.ExecuteReader())
		{
		    while (reader.Read())
		    {
			for (int i = 0; i < reader.FieldCount; i++)
			{
			    Console.WriteLine(reader.GetValue(i));
			}
			Console.WriteLine();
		    }
		}
	    }
