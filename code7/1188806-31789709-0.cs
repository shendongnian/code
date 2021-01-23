    public abstract class EntityBase<TId>
    {
        [BsonId]
        public TId Id { get; set; }
    }
