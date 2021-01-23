    public class Method1Client : LotsOfMethodsDecorator
    {
    	public Method1Client(ILotsOfMethods lotsOfMethods)
    		: base(lotsOfMethods)
    	{
    	
    	}
    	
    	public override bool Method1(string arg)
    	{
    		return  arg == "shouldContinue";
    	}
    }
