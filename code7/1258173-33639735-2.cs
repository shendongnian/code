    //Consider renaming this method; you're really here to get the customers,
    //not create a connection
    public static YourCollectionType<BsonDocument> CreateConnection()
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("orders");
        //Get a handle on the customers collection:
        return database.GetCollection<BsonDocument>("customers");
    }
