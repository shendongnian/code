    public class TaskGroup
    {
        public TaskStatus Status { get; set; }
        public IList<Task> Tasks { get; set; }
    
        public TaskGroup()
        {
            Tasks = new List<Task>();
        }
    }
    
    public class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
    }
    
    public enum TaskStatus
    {
        ToDo = 0,
        InProgress = 1,
        InTesting = 2,
        Done = 3
    }
