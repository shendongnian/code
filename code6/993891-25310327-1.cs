    public IHttpActionResult CreateNew(NewTask task)
    {
         // do something with task.TaskType and task.TaskName here
    }
    public class NewTask
    {
        public int? TaskType { get;set; }
        public string TaskName { get; set; }
    }
