    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Other Web API configuration code goes here
            // This is a globally registered attribute
            config.Filters.Add(new LocalRequestOnlyAttribute()); 
        }
    }
    public class LocalRequestOnlyAttribute : AuthorizeAttribute
    {
    	protected override bool IsAuthorized(HttpActionContext context)
      	{
          	return context.RequestContext.IsLocal;
      	}
    }
