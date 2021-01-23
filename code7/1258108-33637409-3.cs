    static Program()
    {
        _client = new MongoClient();
        _database = _client.GetDatabase("test");
    }
