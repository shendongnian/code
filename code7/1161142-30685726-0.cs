    public class Agent
    {
        protected IPhysics PluginPhysics { get; private set; }
    	
    	protected Agent(IPhysics physicsPlugin) 
    	{
    		PluginPhysics = physicsPlugin;
    	}
    }
    
    public class Bicycle : Agent
    {
    	public Bicycle(IPhysics physicsPlugin)
    		: base(physicsPlugin)
    	{
    		Console.WriteLine("Bicycle ctor");
    	}
    }
