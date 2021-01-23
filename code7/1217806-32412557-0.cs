    public class Executor : IExecutor
    {
       public String Name { get; set;}
       
       public async Task<int> Execute()
       {
       	  Console.WriteLine("Executing " + Name);
    	  await Task.Delay(3000);
    	  Console.WriteLine("Finished Executing " + Name);
    	  return 0;
       }
    }
    public async Task<ExecutorResult> Execute(IExecutor executor)
    {
    	return new ExecutorResult { ExecutorName = executor.Name,
    								Result = await executor.Execute() };
    }
    
    public async Task MainAsync()
    {
        var executors = new List<IExecutor>
    	{
    		new Executor { Name = "Executor1" },
    		new Executor { Name = "Executor2" },
    		new Executor { Name = "Executor3" }
    	};
    	
    	List<Task<ExecutorResult>> tasks = new List<Task<ExecutorResult>>();
    	
    	foreach(var executor in executors)
    	{
    		tasks.Add(Execute(executor));
    	}
    
     	var results = await Task.WhenAll(tasks);
    }
    
    void Main()
    {
    	MainAsync().Wait();
    }
