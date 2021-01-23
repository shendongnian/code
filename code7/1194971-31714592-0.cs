    public class TasksViewModel
    {
      public IEnumerable<TaskBase> Tasks {get; set; }
    }
    // Removed (s), it's best practice to only use s on collections
    public class WorkTask : BaseTask
    {
      public String Company { get; set; }
    }
    // Removed (s), it's best practice to only use s on collections
    public class HomeTask : BaseTask
    {
      public String UserName{ get; set; }
    }
