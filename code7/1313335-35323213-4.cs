    public class User
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public virtual ICollection<Role> Roles { get; set; }
    }
    
    public class Role
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
       public virtual ICollection<User> Users { get; set; }
    }
