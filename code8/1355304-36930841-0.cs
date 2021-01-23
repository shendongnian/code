    public class Group
    {
        public int Id { get; set; }
        public virtual ICollection<User> Users{ get; set; }
    }
    
    public class User
    {
        public int Id { get; set; }
        public virtual Group Group { get; set; }
    }
