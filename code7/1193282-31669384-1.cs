    public class MyCustomUriMapper : UriMapperBase
    {
    	public override Uri MapUri(Uri uri)
        {
    		var tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());
    		
    		if (tempUri.StartsWith("/mynotification"))
            {
    			// Check your uri param and redirect to a page with uri
    			// or set some properties to check in your MainPage
            }
    
    	}
    }
