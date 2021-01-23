    public interface IEntity {
        [BsonId]
        string Id { get; set; }
    
        string IdEntity { get; set; }
    }
    
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class BaseEntity : IEntity 
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }
    
        [BsonIgnoreIfNull]
        public string IdEntity { get; set; }
    }
