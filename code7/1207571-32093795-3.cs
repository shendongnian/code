    public class FooViewModel
    {
        public FooViewModel()
        {
           Tasks = new List<Task>();
           EmpIds = new List<string>();
        }
        public List<Task> Tasks { get; set; }
        public List<string> EmpIds { get; set; }
    }
