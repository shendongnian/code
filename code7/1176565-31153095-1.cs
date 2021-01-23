	public class TaskParamsType
	{
		IList<string> Locations
		IList<int> Iterations
	}
	
	public class ITaskDataNew 
	{
		public TaskParamsType TaskParams { get; set; } 
	}
	var result = taskDataList.Where(td => 
		td.TaskParams.Locations.Contains("Stockroom") &&
		td.TaskParams.Iterations.Contains(1)
		);
