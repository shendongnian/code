    using MongoDB.Driver;
    namespace DataImport
    {
    class Mongo
    {
        public static void SendingRecord(Products output)
        {
            // Connecting to MongoDB
            string connectionString = "mongodb://localhost:27017";
            MongoClient mongoClient = new MongoClient(connectionString);
            // Navigating to DB and Collection
            var db = mongoClient.GetDatabase("DB-name");
            var products = db.GetCollection<Products>("Collection-Name");
            // Importing new documents or updating existing ones
            var options = new UpdateOptions();
            options.IsUpsert = true;
            products.ReplaceOne(filter: x => x.uniqueField == output.uniqueField, replacement: output, options: options);
        }
    }
