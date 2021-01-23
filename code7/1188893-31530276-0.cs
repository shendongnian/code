    public interface IWrapperService
    {
    	Method(Dto model);
    	
    	Dto MethodProcess(Dto model);
    }
    
    public class WrapperService : IWrapperService
    {
    	private readonly ThirdPartyLib _thirdPartyLib;
    
    	public WrapperService(ThirdPartyLib thirdPartyLib)
    	{
    		_thirdPartyLib = thirdPartyLib;
    	}
    	
    	// Create your model - Dto
    	// Dto will help you in your logic process
    	// 
    	public void Method(Dto model)
    	{	
    		//extract some properties in you model that only needed in your third party library	
    		_thirdPartyLib.Method(parameter needed);
    	}
    	
    	public Dto MethodProcess(Dto model)
    	{	
    		//extract some properties in you model that only needed in your third party library	
    		ThirdPartyReturn value = _thirdPartyLib.MethodProcess(parameter needed);
    		
    		// Do the mapping
    		var model = new Dto 
    		{
    			property1 = value.property1 // Do the necessary convertion if needed.
    			.
    			.
    		}
    		
    		return model;
    	}
    	.
    	.
    	.
    }
    public interface IOtherClass 
    {
      ...
    }
    
    public class OtherClass : IOtherClass 
    {
       private readonly IWrapperService _wrapperService;
    
       public void OtherClass(IWrapperService wrapperService)
       {
            _wrapperService= wrapperService;
       }
       .
       .
    }
