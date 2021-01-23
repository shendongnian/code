    public class EntityParent : IEntity
    {
        public string Id { get; }
        public string EntityChild { get; }
        [JsonConstructor]
        public EntityParent(string id, string entityChild)
        {
            Id = id;
            EntityChild = entityChild;
        }
    }
