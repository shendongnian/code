    public Doc GetFirstExistingDocument()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("test");
    
        return database.GetCollection<Doc>("docs")
            .Find(doc => !doc.Deleted)
            .Sort(Builders<Doc>.Sort.Ascending(doc => doc.Date))
            .First();
    }
