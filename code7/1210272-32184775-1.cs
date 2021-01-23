    public class User 
    {
        //Some properties
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
    public class Role
    {
        public virtual ICollection<UserRole> UserRoles{ get; set; }
    }
    public class Role
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
 
