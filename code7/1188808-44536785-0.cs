    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Language), typeof(OtherEntity))]
    public abstract class EntityBase
    {
        [BsonId]
        public virtual string Id { get; set; }
    }
