    public List<BsonDocument> getAllData()
    {
        try
        {
            var connectionString = "mongodb://172.16.1.24:27017";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("kljenti");
            var Client = new MongoClient();
            var DB = Client.GetDatabase("knjigoMata");
            var kolekcija = DB.GetCollection<BsonDocument>("kljenti");
            Task<List<BsonDocument>> task = kolekcija.Find(new BsonDocument()).ToListAsync();
            task.Wait();
            List<BsonDocument> allDocuments = task.Result;
            foreach (var kljenti in allDocuments)
            {
                Console.WriteLine(kljenti);
            }
            return allDocuments;
        }
        catch
        {
            MessageBox.Show("Nemogu prikazati podatke o korisnicima");
        }
    }
