    public interface ILotsOfMethods
    { 
        // Lots of methods go here
    	bool Method1(string arg);
    	bool Method2(string arg);
    	TimeSpan Method6(string arg);
    }
    
    public abstract class LotsOfMethodsDecorator : ILotsOfMethods
    {
    	private readonly ILotsOfMethods LotsOfMethodsToBeDecorated;
    
    	protected LotsOfMethodsDecorator(ILotsOfMethods lotsOfMethods)
    	{
    		this.LotsOfMethodsToBeDecorated = lotsOfMethods;
    	}
    
    	public virtual bool Method1(string arg)
    	{
    		return LotsOfMethodsToBeDecorated.Method1(arg);
    	}
    	
    	public virtual bool Method2(string arg)
    	{
    		return LotsOfMethodsToBeDecorated.Method2(arg);
    	}
    	
    	public virtual TimeSpan Method6(string arg)
    	{
    		return LotsOfMethodsToBeDecorated.Method6(arg);
    	}
    }
