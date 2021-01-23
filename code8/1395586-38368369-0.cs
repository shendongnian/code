		string password;
		var connection = Database.GetDbConnection();
		connection.Open();
		using (var command = connection.CreateCommand())
		{
			command.CommandText = $"PRAGMA key='{password}';";
			command.ExecuteNonQuery();
		}
