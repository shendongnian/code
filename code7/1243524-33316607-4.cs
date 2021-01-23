    public class OptionalsRouteAttribute : RouteFactoryAttribute
    {
    	private object _defaults;
    	public OptionalsRouteAttribute(string template, object defaults)
    		: base(template)
    	{
    		Defaults = defaults;
    	}
    	
    	[...]
    }
