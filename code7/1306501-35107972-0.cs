    static void Main() {
       MainAsync().Wait();
    }
    
    static async Task MainAsync() {
    
        var client = new MongoClient();
        var db = client.GetDatabase("SoundsDB");
        var collection = db.GetCollection<Sound>("SoundsCollection");
        string myID = "0vvyXSoSHI";
    
        var myObjects = await collection
            .Find(b => b.objectId == myID).ToListAsync();
    
    }
