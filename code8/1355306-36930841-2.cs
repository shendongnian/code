    public class User
    {
        public int Id { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
