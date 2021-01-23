    public class Entity
    {
        [BsonElement("_id")]
        public string Id { get; set; }
    }
    
    public class DTO : Entity 
    {
        [BsonElement("bd")]
        public DateTime BusinessDate { get; set; }
        // etc
    }
