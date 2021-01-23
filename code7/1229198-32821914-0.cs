         public IMongoDatabase getMongoDB() 
         {
            IMongoClient client = new MongoClient("mongodb://localhost:27017");
            var iMgDb = client.GetDatabase("Database Name Here");
            return iMgDb;
         }
