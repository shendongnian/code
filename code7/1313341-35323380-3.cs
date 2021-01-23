    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
        public User()
        {
            this.Roles = new Collection<Role>();
        }
    }
