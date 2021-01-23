    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
    }
