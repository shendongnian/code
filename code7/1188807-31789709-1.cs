    public class Language : EntityBase<string>
    {
        [BsonExtraElements]
        public IDictionary<string, object> Terms { get; set; }
    }
