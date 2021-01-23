    public class GenericMethodClass
    {
    	
    	public string ABC<T>(T obj) where T : IDestination, IDestinationLogic
    	{
    		var result = string.Empty;
    		//some code happens here
    		var typeConditionalLogicResult = obj.DoSomething();	
    		// do more stuff with according to the result of type-specific calculations
    		return result;
    	}
    }
    	
    	
    public class ClassA: IDestination, IDestinationLogic
    {
    	public string Var1 { get; set; }    
    	public string Var2 { get; set; }    
    	public string Var3 { get; set; }
    	
    	public string DoSomething()
    	{
    		return Var2;		
    	}
    }
    
    public class ClassB: IDestination, IDestinationLogic
    {
    	public string Var1 { get; set; }
    	public string Var2 { get; set; }
    	public string Var3 { get; set; }
    	public string Var4 { get; set; }
    	public string Var5 { get; set; }
    	
    	public string DoSomething()
    	{
    		return Var4;		
    	}
    }
    
    public interface IDestination
    {
    	string Var1 { get; set; }
    	string Var2 { get; set; }	
    }
    
    public interface IDestinationLogic
    {
    	string DoSomething();	
    }
