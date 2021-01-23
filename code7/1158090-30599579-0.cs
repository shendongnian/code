        public async Task<IEnumerable<ProductCategory>> getAllCategories()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<ProductCategory>("productcategory");
            var documents = await collection.Find(_ => true).ToListAsync();
            return documents;
        }
