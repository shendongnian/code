    public class Activity
    {
        public int Id { set; get; }
        public virtual ICollection<Relationship> Successors { get; set; }
        public virtual ICollection<Relationship> Predecessors { get; set; }
    }
    public class Relationship
    {
        public int Id { set; get; }
        public virtual Activity Activity1 { get; set; }
        public int Activity1_ID { get; set; }
        public virtual Activity Activity2 { get; set; }
        public int Activity2_ID { get; set; }
    }
