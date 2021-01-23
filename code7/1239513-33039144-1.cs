    ccDc = getDataContext();
    using (SqlCommand command = new SqlCommand(
		string.Format("SELECT HASHBYTES('MD5', ChunkData) FROM dbo.x where id={0}", Id),
		ccDc))
    {
		using (SqlDataReader reader = command.ExecuteReader())
		{
		    while (reader.Read())
		    {
			    for (int i = 0; i < reader.FieldCount; i++)
			    {
			        Console.WriteLine(reader.GetValue(i)); // or do whatever you want with the results...
			    }
		    }
		}
    }
