    public List<string> GetCollections()
    {
    	List<string> collections = new List<string>();
    
    	foreach (BsonDocument collection in _database.ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
    	{
    		string name = collection["name"].AsString;
    		collections.Add(name);
    	}
    
    	return collections;
