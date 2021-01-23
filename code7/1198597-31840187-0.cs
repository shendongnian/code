    public class IndexController : ApiController
    {
    	[AllowAnonymous]
    	[Route]
    	public HttpResponseMessage GetIndex()
    	{
    		string startUrl = "/help/";
    		if (!Helpers.Configuration.ConfigurationsAreInPlace())
    		{
    			startUrl += "offline";
    		}
    		HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Moved);
    		string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
    		response.Headers.Location = new Uri(fullyQualifiedUrl + startUrl);
    		return response;
    	}
    }
