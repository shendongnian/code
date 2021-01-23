    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;    
    public class Object
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public long StartTimestamp { get; set; }
        public long EndTimestamp { get; set; }
    }
