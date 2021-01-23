    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public Role()
        {
            this.UserRoles = new Collection<UserRole>();
        }
    }
