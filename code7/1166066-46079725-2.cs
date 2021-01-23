    class DataAccess
    {
        private TestProductContext _testProductContext;
        public DataAccess(TestProductContext testProductContext)
        {
            _testProductContext = testProductContext;
        }
        public List<Product> GetProducts()
        {
            List<Product> pto = new List<Product>();
            var cursor = _testProductContext.Products.Find(new BsonDocument()).ToCursor();
            foreach (var document in cursor.ToEnumerable())
            {
                pto.Add(document);
            }
        }
    }
