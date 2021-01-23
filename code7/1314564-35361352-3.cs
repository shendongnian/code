    abstract class Entity
    {
        static string DatabaseConnectionString = "shared_across_implementations";
    
        protected Entity(XDocument) {...}
        protected Entity(string) {...}
    }
    class EntityBAR : Entity
    {
        public Entity(XDocument) : base(XDocument) {...}
        public Entity(string) : base(string) {...}
    }
