    public class Task
    {
    	public event EventHandler<TaskStatusEventArgs> StatusChanged;
    	//...
    }
    
    public enum TaskStatus
    {
    	New,
    	
    	InProgress,
    	
    	Done
    }
    
    public class TaskStatusEventArgs: EventArgs
    {
    	public string TaskName { get; private set; }
    	
    	public TaskStatus Status { get; private set; }
    
    	public TaskStatusEventArgs(string taskName, TaskStatus status)
    	{
    		TaskName = taskName;
    		Status = status;
    	}
    }
