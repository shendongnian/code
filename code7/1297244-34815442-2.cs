    public class Parent
    {
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public virtual ICollection<Child> Children { get; set; }
       //..
    }
