    public class User : BaseEntity
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual UserGroup UserGroup { get; set; }
        public virtual UserInGroup UserInGroup { get; set; }
    }
    public class UserGroup : BaseEntity
    {
        public UserGroup()
        {
            Users = new HashSet<User>(); // HashSet is more effective than List
            UserInGroups = new HashSet<UserInGroup>();
        }
        [StringLength(255)]
        public string Name { get; set; }
        public string KeyName { get; set; }
        public virtual ICollection<User> Users { get; set; } // ICollection is less restrective
        public virtual ICollection<UserInGroup> UserInGroups { get; set; }
    }
