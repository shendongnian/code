    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }
        public virtual int UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual IList<Role> Roles { get; set; }
    }
    public class Role
    {
        public virtual Guid RoleId { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<User> Users { get; set; }
    }
