    public class Project
    {
        public int ProjectId { get; set; }
    }
    
    public class ProjectTask
    {
        public int ProjectTaskId { get; set; }
        public virtual Project Project { get; set; }
        public string SomeString { get; set; }
    }
    public class ProjectET : ProjectTask
    {
        public ICollection<Order> ECOs { get; set; }
    }
    public class Order
    {
        public int OrderId { get; set; }
        public string SomeString { get; set; }
    }
