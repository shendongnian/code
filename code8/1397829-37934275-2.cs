    try
    {
        string connectstring1 = "mongodb://user1:password1@ds*****.mlab.com:234***/dbname";
        MongoClient client = new MongoClient(connectstring1);
        var db = client.GetDatabase("dbname");
        var collection = db.GetCollection<BsonDocument>("collectionName");
        var filter1 = Builders<BsonDocument>.Filter.Empty;
        var filter = new BsonDocument();
        using (var cursor = await collection.FindAsync(filter))
        {
            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (var document in batch)
                {
                    MessageBox.Show(document[1].ToString(), "msg");
                }
            }
        }
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
