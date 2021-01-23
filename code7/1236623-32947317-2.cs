    static void insert()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("YUSUF");
           
           var collection = database.GetCollection<Expression>("expressions");
              var expression = new Expression { Id = Guid.NewGuid().ToString(),ExpressionSentence = "Test",Name = "yusuf",CreatedDate = DateTime.Now,Status = true };
            collection.InsertOneAsync(expression);
        }
     public class Expression {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ExpressionSentence { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
