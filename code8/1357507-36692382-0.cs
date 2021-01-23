    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class TopicMapper
    {
        [BsonElement("title")]
        public string Name { get; set; }
        [BsonElement("id")]
        public int Identity { get; set; }
    }
