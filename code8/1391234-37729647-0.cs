    void Main()
    {
	var actionlog = new Dictionary<string, Action[]>();
	actionlog.Add("T1", new Action[] { () => {
					Console.WriteLine("Test1");Thread.Sleep(2000);}, () => Console.WriteLine("LogTest1") });
	actionlog.Add("T2", new Action[] { () => {
					Console.WriteLine("Test2");Thread.Sleep(2000);}, () => Console.WriteLine("LogTest2") });
	actionlog.Add("T3", new Action[] { () => {
					Console.WriteLine("Test3");Thread.Sleep(2000);}, () => Console.WriteLine("LogTest3") });
	actionlog.Add("T4", new Action[] { () => {
					Console.WriteLine("Test4");Thread.Sleep(2000);}, () => Console.WriteLine("LogTest4") });
	actionlog.Add("T5", new Action[] { () => {
					Console.WriteLine("Test5");Thread.Sleep(2000);}, () => Console.WriteLine("LogTest5") });
	actionlog.Add("T6", new Action[] { () => {
					Console.WriteLine("Test6"); Thread.Sleep(2000); }, () => Console.WriteLine("LogTest6") });
	
	var task = GetTaskChain(actionlog);
	
	task.Start();
    }
    
    public Task GetTaskChain(Dictionary<string, Action[]> actionlog)
    {
	CancellationToken token = new CancellationToken();
	var TaskList = new List<Task>();
	foreach (var item in actionlog.Values)
	{
		if (TaskList.Count == 0)
		{
			var task = new Task(item[0]);
			var LogAct = task.ContinueWith((t) => item[1](), token, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);
			TaskList.AddRange(new[] { task, LogAct });
		}
		else
		{
			var task = TaskList[TaskList.Count - 1].ContinueWith((t) => item[0](), token, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);
			var LogAct = task.ContinueWith((t) => item[1](), token, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);
			TaskList.AddRange(new[] { task, LogAct });
		}
	}
	return TaskList[0];
    }  
