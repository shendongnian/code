    public class WindowsService : IWindowsService
    {
    	private SchedulerRegistry registry;
    
    	public WindowsService(SchedulerRegistry schedulerRegistry)
    	{
    		this.registry = schedulerRegistry;  
    	}
    
    	public void Start()
    	{
    		Console.WriteLine("Service started");
    
    		JobManager.Initialize(this.registry);
    	}
    
    	public void Stop()
    	{
    		Console.WriteLine("Service stopped");
    	}
    }
