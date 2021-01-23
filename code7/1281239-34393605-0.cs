    public static string GetPrimaryDatabase()
    {
		var mongoClient = new MongoClient(clientSettings);
		var server = mongoClient.GetServer();
		var database = server.GetDatabase("test");
		var cmd = new CommandDocument("isMaster", "1");
		var result = database.RunCommand(cmd);
		var responses = result.Response;
		var primaryDatabase = responses.Where(response => response.ToString().Contains("primary"));
			var primaryDatabaseName = string.Empty;
			foreach (var bsonElement in primaryDatabase)
			{
				primaryDatabaseName = bsonElement.Value.ToString();
			}
			return primaryDatabaseName;
		}
