    void InsertDiece(string connectionString, string tableName, int count)
    {
    	var commandText = String.Format("INSERT INTO `{0}` (Dice1, Dice2) Values (@dice1, @dice2)", tableName);
    	var random = new Random(DateTime.Now.Milliseconds);
    	using(var connection = new MySqlConnection(connectionString))
    	using(var command = connection.CreateCommand())
    	{
    		connection.Open();
    		command.CommandText = commandText;
    		for(int i = 0; i < count; i++)
    		{
    			command.Parameters.AddWithValue("@dice1", random.Next(1, 7));
    			command.Parameters.AddWithValue("@dice2", random.Next(1, 7));
    			command.ExecuteNonQuery();
    			command.Parameters.Clear();
    		}
    	}
    }
