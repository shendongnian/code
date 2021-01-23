    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int, AllowTruncation=true)]
        public string id { get; set; }
        [BsonRepresentation(BsonType.Int, AllowTruncation=true)]
        public int value { get; set; }        
    }
