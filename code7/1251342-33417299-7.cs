    public partial class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
    
        public int UserId { get; set; }
        //...
        public virtual ICollection<UsersInRoles> Roles { get; set; }
    }
    public partial class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
    
        public int RoleId { get; set; }
       
        public virtual ICollection<UsersInRoles> Users { get; set; }
    }
    public class UsersInRoles
    {
        [Key, Column(Order = 0),ForeignKey("User")]
        public int UserId { get; set; }
        [Key, Column(Order = 1),ForeignKey("Role")]
        public int RoleId { get; set; }
        
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
       
       //add new properties here
    } 
