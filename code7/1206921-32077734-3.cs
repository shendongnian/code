    public class Some3rdPartQueryWrapper : LotsOfMethodsDecorator
    {
    	private readonly Some3rdPartyQuery Query;
    	
    	public Some3rdPartQueryWrapper(Some3rdPartyQuery query, ILotsOfMethods lotsOfMethods)
    		: base(lotsOfMethods)
    	{
    		this.Query = query;
    	}
    	
    	public override bool Method2(string arg)
    	{
    		if (this.Query.MaybeSomeThirdPartyValidation())
    			return false;
    		else
    			return this.Query.SomeThirdPartyMethod2(arg);
    	}
    }
