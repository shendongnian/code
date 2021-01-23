    public class User
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string NickName { get; set; }
        public string Info { get; set; }
        public bool Available { get; set; }
    }
    ...
    // In your containing type
    public List<User> Users { get; set; }
