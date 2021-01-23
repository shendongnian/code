    public class User
    {
        public int Id { get; set; }
    
        // other properties
        // ...
        
        // UserRole association
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
    
    public class Role
    {
        public int Id { get; set; }
    
        // other properties
        // ...
        
        // UserRole association
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
