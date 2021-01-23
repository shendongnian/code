    public static async Task insert(){
    const string connectionString = "mongodb://localhost:27017";
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);
            ////Use the MongoClient to access the server
            var database = client.GetDatabase("YUSUF");
            ////get mongodb collection
            var collection = database.GetCollection("expressions");
            var expression = new Expression { Id = Guid.NewGuid().ToString(),ExpressionSentence = "Test",Name = "yusuf",CreatedDate = DateTime.Now,Status = true };
             await collection.InsertOneAsync(expression);
     }
      public class Expression {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ExpressionSentence { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
     
