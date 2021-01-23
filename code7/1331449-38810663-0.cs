	public class SnakeQueryStringValueProviderFactory : QueryStringValueProviderFactory
	{
		public override IValueProvider GetValueProvider( HttpActionContext actionContext )
		{
			var pairs = actionContext.ControllerContext.Request.GetQueryNameValuePairs();
			// modify query string keys accordingly
			// e.g. remove '_' from query string keys 
			// var newPairs = ...
			return new NameValuePairsValueProvider( newPairs, CultureInfo.InvariantCulture );
		}
	}
