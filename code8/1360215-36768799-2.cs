    public int loginUser(string userName, string pass)
        {
            int result = 0;
            //Here you use credentials for the connection, not the one passed
            //to the method:
            var credentials = MongoCredential.CreateMongoCRCredential("SearchForKnowledge", connectionUsername, connectionPass);
            var settings = new MongoClientSettings
            {
                Credentials = new[] { credentials }
            };
            try
            {
                var mongoClient = new MongoClient(settings);
                var database = mongoClient.GetDatabase("SearchForKnowledge");
                var coll = database.GetCollection<BsonDocument>("Users");
    
                var filter = Builders<BsonDocument>.Filter.Eq("userName", userName);
                var result = await coll.Find(filter).ToListAsync().First();
                if(result["Password"] == pass)
                {
                   result = 1;
                }
            }
            catch (Exception ex) {
                result = 0;
            }
            return result;
