    protected static IMongoClient _client;
    protected static IMongoDatabase _database;
    static void Main(string[] args)
    {
        _client = new MongoClient();
        _database = _client.GetDatabase("test");
        GetDataAsync().Wait(); 
        // Will block the calling thread but you don't have any other solution in a console application
    }
    private static async Task GetDataAsync() //method added by me.
    {
        int x = await GetData();
    }
    private static async Task<int> GetData()
    {
        var collection = _database.GetCollection<BsonDocument>("restaurants");
        var filter = new BsonDocument();
        var count = 0;
        Func<int> task = () => count; //added by me.
        var result = new Task<int>(task); //added by me.
        using (var cursor = await collection.FindAsync(filter)) //Debugger immediately exits here, goes back to main() and then terminates. 
        {
            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (var document in batch)
                {
                    // process document
                    count++;
                }
            }
        }
        return count; //added by me
    }
