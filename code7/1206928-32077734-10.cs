    public class MethodAwareClient : LotsOfMethodsDecorator
    {
    	public MethodAwareClient(ILotsOfMethods lotsOfMethods)
    		: base(lotsOfMethods)
    	{
    	
    	}
    	
    	public void HandleForm()
    	{
    		if (Method1("shouldContinue"))
    		{
    			//...
    		}
    		
    		if (Method2("needSleep"))
    		{
    			Task.Delay(Method6("sleepTime"));
    		}
    	}
    }
