    public class ErrorController : BaseController
    {
    	public ActionResult PageNotFound()
    	{
    		Response.StatusDescription = "Page not found";
    		Response.StatusCode = (int)HttpStatusCode.NotFound;
    		Response.TrySkipIisCustomErrors = true;
    
    		return Content(string.Empty);
    	}
    }
