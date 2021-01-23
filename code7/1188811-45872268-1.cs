    public class SuperBaseEntity
    {
        [BsonIgnore]
        public string Id { get; set; }
    }
    public class ObjectIdBaseEntity : SuperBaseEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public new string Id { get; set; }
    }
    public class StringIdBaseEntity : SuperBaseEntity
    {
        [BsonRepresentation(BsonType.String)]
        public new string Id { get; set; }
    }
    public class Language : StringIdBaseEntity
    {
        [BsonExtraElements]
        public IDictionary<string, object> Terms { get; set; }
    }
    public class AllOtherEntities : ObjectIdBaseEntity
    {
        ...
    }
