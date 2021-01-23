    public class Command
    {
    	public string start { get; set; }
    	public string stop { get; set; }
    	public string restart { get; set; }
    }
    
    public class Process
    {
    	public string name { get; set; }
    	public Command command { get; set; }
    }
    
    public class Services
    {
    	public string service { get; set; }
    	public List<Process> processes { get; set; }
    }
