    public class User
    {
        public string UserName { get; set; }
        public List<Entity> Entities { get; set; }
    }
    
    public class Entity {
        public string PKey { get; set; }
    }
