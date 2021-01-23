    public static string GetPrimaryDatabase()
	{
		var mongoClient = new MongoClient(clientSettings);
		var server = mongoClient.GetServer();
		var database = server.GetDatabase("test");
		var cmd = new CommandDocument("isMaster", "1");
		var result = database.RunCommand(cmd);
			return result.Response.FirstOrDefault(
              response => response.ToString().Contains("primary")).Value.ToString();
	}
