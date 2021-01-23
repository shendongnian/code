    public class EnvSettings
    {
    	public bool IsDebug {get; private set;}
    	public EnvSettings(bool isDebug)
    	{
    		IsDebug = isDebug;
    	}	
    }
    
    // then  elsewhere
    
    public void Foo()
    {
        var settings = EnvSettings(false);
    	if(settings.IsDebug)
    	{
    		// this is debug
    	}
    	else
    	{
    		// this is something else
    	}
    }
