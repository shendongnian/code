    SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
    builder.DataSource = "test.db";
    SQLiteConnection connection = new SQLiteConnection(builder.ConnectionString);
    using (connection.Open())
	{
		SQLiteCommand command = new SQLiteCommand("select * from people limit @limitNum", connection);
		command.Parameters.Add(new SQLiteParameter("limitNum", 2));
		SQLiteDataReader reader = command.ExecuteReader();
		while (reader.Read())
		{
			Console.WriteLine(reader.GetValue(0));
		}
	}
