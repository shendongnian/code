    public class AuthResource
    {
         public long ResourceId { get; private set; }
         public int ResourceType { get; private set; }
    }
    public class AuthEntity : AuthResource
    {
        public int Id { get; set; }   
        public int ActionId { get; set; }
    }
