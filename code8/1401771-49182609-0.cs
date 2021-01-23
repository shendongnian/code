    var context = new SampleDbContext();
    using (var connection = context.Database.GetDbConnection())
    {
    	connection.Open();
    
    	using (var command = connection.CreateCommand())
    	{
    		command.CommandText = "SELECT COUNT(*) FROM SomeTable";
    		var result = command.ExecuteScalar().ToString();
    	}
    }
