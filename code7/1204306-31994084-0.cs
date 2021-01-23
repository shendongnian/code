    public class Parent
    {
        public virtual ICollection<Child> Children { get; set; }
    }
    public class Child
    {
        public virtual Parent Parent { get; set; }
    }
