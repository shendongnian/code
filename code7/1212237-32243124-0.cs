    class EntityDto
    {
        public int EntityId { get; set; }
    }
    class EntityId<T>
    {
        public T Id { get; set; }
    }
    class Entity
    {
        public EntityId<int> EntityId { get; set; }
    }
