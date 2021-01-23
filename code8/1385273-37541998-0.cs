    public class User
    {
        public int Id { get; set; }
    
        // other properties
        // ...
        
        // UserRole association
        public virtual ICollection<Role> Roles { get; set; }
    }
    
    public class Role
    {
        public int Id { get; set; }
    
        // other properties
        // ...
        
        // UserRole association
        public virtual ICollection<User> Users { get; set; }
    }
