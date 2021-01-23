	public class TaskMap
	{
		public string TaskId { get; set; }
		public string TaskParentId { get; set; }
		public virtual Task Task { get; set; }
		public virtual Task ParentTask { get; set; }
	}
	
	public class Task
	{
		public string TaskId { get; set; }
		public int Progress { get; set; }
		public virtual ICollection<TaskMap> SubTasks { get; set; }
	}	
