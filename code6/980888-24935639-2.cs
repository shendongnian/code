    config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());
    public class CustomDirectRouteProvider : DefaultDirectRouteProvider
    {
    	protected override IReadOnlyList 
    	GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
    	{
    		return actionDescriptor.GetCustomAttributes
    		(inherit: true);
    	}
    }
