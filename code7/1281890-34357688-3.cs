    var mongoClient = new MongoClient(clientSettings);
    var testDB = mongoClient.GetDatabase("test");
    string userName = "test1";
    var cmd = new BsonDocument("usersInfo", userName);
    var queryResult = testDB.RunCommand<BsonDocument>(cmd);
    var roles = (BsonArray)queryResult[0][0]["roles"];
    var result = from roleDetail in roles select new {Role=roleDetail["role"].AsBsonValue.ToString(),RoleDB=roleDetail["db"].AsBsonValue.ToString()};
