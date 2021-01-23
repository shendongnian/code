    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public User()
        {
            this.UserRoles = new Collection<UserRole>();
        }
    }
