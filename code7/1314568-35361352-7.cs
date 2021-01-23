    abstract class Entity
    {
        static string DatabaseConnectionString = "shared_across_implementations";
    
        protected Entity(XDocument) {...}
        protected Entity(string) {...}
    }
    class EntityBAR : Entity
    {
        public EntityBAR(XDocument) : base(XDocument) {...}
        public EntityBAR(string) : base(string) {...}
    }
