    public abstract class BuildAction
    {
    	public string Description { get; set; }
    
    	protected BuildAction(string description)
    	{
    		Description = description;
    	}
    
    	public abstract void PerformBuildAction();
    }
    
    public class BuildTest : BuildAction
    {
    	public BuildTest() : base("Build the test with the supplied designator as 'arg_designator'") { }
    
    	public override void PerformBuildAction() 
    	{
    		// do stuff here
    	}
    }
    
    public class ChangeRole : BuildAction
    {
    	public ChangeRole() : base("Change the user's role") { }
    
    	public override void PerformBuildAction()
    	{
    		// do stuff here
    	}
    }
    
    public class CheckoutData : BuildAction
    {
    	public CheckoutData : base("Check out the data you wish to test") { }
    
    	public override void PerformBuildAction()
    	{
    		// do stuff here
    	}
    }
