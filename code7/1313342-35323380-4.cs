    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public Role()
        {
            this.Users = new Collection<User>();
        }
    }
