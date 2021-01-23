    public class Note
    {
      [BsonId] public long Id { get; set; }
      [BsonElement("content")] public string Content { get; set; }
    }
