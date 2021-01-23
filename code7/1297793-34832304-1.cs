    public class MyType
    {
        public BsonObjectId _id { get; set; }
        public BsonString text { get; set; }
        [BsonExtraElements]
        public BsonDocument CatchAll { get; set; }
    }
