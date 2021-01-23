    public static List<Customer> LoadCustomers()
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("orders");
        //Get a handle on the customers collection:
        var collection = database.GetCollection<Customer>("customers");
        var docs = collection.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
        return docs;            
    } 
