    public class Chat
    {
        public IQueryable<User> Users { get; set; }
    }
    
    public class User
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
    }
    
    public class ChatDTO
    {
        public string Users { get; set; }
    }
