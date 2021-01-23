    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();
        }
    }
    public class Activity
    {
        public string Name { get; set; }
        List<Task> Tasks { get; set; }
    }
    public class Task
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Priority Priority { get; set; }
    }
    public class Priority
    {
        public string Name { get; set; }//--or however you want to structure this class, this could also be an enum
    }
