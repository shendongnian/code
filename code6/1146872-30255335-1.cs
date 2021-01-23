    namespace MyApp.MongoDb
    {
        public class User
        {
            [BsonId]
            public int Id { get; set; }
    
            [BsonElement("Username")]
            public string Username { get; set; }
    
            [BsonElement("Email")]
            public string Email { get; set; }
        }
    }
