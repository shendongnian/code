    static void Main(string[] args)
    {
        _client = new MongoClient();
        _database = _client.GetDatabase("test");
        GetDataAsync().Wait(); 
        // Will block the calling thread but you don't have any other solution in a console application
    }
