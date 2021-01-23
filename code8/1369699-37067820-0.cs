    public List<Post> getAllProgramming() 
    {
        var result = new List<Post>();
        var mongoClient = new MongoClient("mongodb://localhost");
        var database = mongoClient.GetDatabase("SearchForKnowledge");
        var coll = database.GetCollection<Post>("Posts");
        var filter = Builders<Post>.Filter.Eq(p => p.CategoryId, 1);
        result = coll.Find(filter).ToList();
    }
