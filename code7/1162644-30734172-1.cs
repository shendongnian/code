    //This isn't strictly needed but it will let you force some
    //Specific fields for the monitoring tool if you like
    public interface IMonitoringTool
    {
        string ForcedProperty { get; set; }
    }
    //Here the type parameter get used for the Configuration property:
    public class MonitorField<T> where T : IMonitoringTool
    {
        public T Configuration { get; set; }
    	public string FieldName { get; set; }
    	
        public MonitorField()
        {
            FieldName = "<label>";
        }
    }
    //And this is the context:
    public class MonitorEntity<T> : DbContext where T : IMonitoringTool
    {
    	public DbSet<Monitor<T>> Monitors { get; set; }
    }
    
    public class Monitor<T> where T : IMonitoringTool
    {
    	public Monitor(string name)
    	{
    		MonitorName = name;
    		FieldList = new List<MonitorField<T>>();
    	}
    
    	public string MonitorName { get; set; }
    	public List<MonitorField<T>> FieldList { get; set; }
       
    }
    
