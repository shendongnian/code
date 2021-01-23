    public class User 
    {
        public int UserId { get; set; }
        public string UserName{ get; set; }
        public string FirstName {get; set;}
        public string LastName {get; set;}
        
        public virtual ICollection<Role> Roles { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        public string Name{ get; set; }
        public string Description{get; set;}
        
        public virtual ICollection<User> Users{ get; set; }
    }
