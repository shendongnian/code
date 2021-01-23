    public class Category
    {
        public Category()
        {
            Tasks = new HashSet<Task>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }
    }
