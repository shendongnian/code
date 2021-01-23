    abstract class CustomConfiguration
    {
    	//current dependency stored in static field
    	private static CustomConfiguration current;
    
    	//static property which gives access to dependency
    	public static CustomConfiguration Current
    	{
    		get
    		{
    			if (current == null)
    			{
    				//Ambient Context can't return null, so we assign a Local Default
    				current = new DefaultCustomConfiguration();
    			}
    
    			return current;
    		}
    		
    		set
    		{
    			//allows to set different implementation of abstraction than Local Default
    			current = (value == null) ? new DefaultCustomConfiguration() : value;
    		}
    	}
    
    	//service which should be override by subclass
    	public virtual string SomeSetting { get; }
    }
    
    //Local Default
    class DefaultCustomConfiguration : CustomConfiguration
    {
    	public override string SomeSetting
    	{
    		get { return "setting"; }
    	}
    }
