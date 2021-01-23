    public class BoringPlugin : Plugin 
    {
    	public override string Output()
    	{
    		return base.Output();
    	}
    }
    
    public class ExcitingPlugin : Plugin
    {
    	public override string Output()
    	{
    		return "No boring defaults here!";
    	}
    }
