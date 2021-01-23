    public class BaseObject {
      [BsonId] public ObjectId id { get; set; }
      [BsonElement("plans")] public List<ThePlan> Plans { get; set; }
    }
    public class ThePlan {
      [BsonElement("i")] public int Integer { get; set; }
      [BsonElement("s")] public string String { get; set; }
    }
