    var connectionString = "some connection string";
    using (var connection = new SqlConnection(connectionString)) {
        connection.Open();
    	using (var command = new SqlCommand("SELECT * FROM Dogs1 WHERE Name LIKE @Name", connection)) {
            command.Parameters.Add(new SqlParameter("Name", dogName));
    		var reader = command.ExecuteReader();
    		while (reader.Read()) {
    		    int weight = reader.GetInt32(0);
    		    string name = reader.GetString(1);
    		    string breed = reader.GetString(2);
    		    Console.WriteLine("Weight = {0}, Name = {1}, Breed = {2}",
    			weight,
    			name,
    			breed);
    		}
        }
    }
