    public class Member
    {
        public int ID { get; set; }
        // ...
        public virtual ICollection<Dog> Dogs { get; set; }
    }
