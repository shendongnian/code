    public int loginUser(string userName, string pass)
        {
            int result = 0;
            var credentials = MongoCredential.CreateMongoCRCredential("SearchForKnowledge", userName, pass);
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
