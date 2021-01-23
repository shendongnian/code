    public static class HttpResponseMessageExtensions
    {
    	public static bool IsOk(this HttpResponseMessage response)
    	{
    		return response.StatusCode == System.Net.HttpStatusCode.OK;
    	}
    
    	public static bool IsHtml(this HttpResponseMessage response)
    	{
    		return response.FirstContentTypeTypes().Contains("text/html");
    	}
    
    	public static bool IsJson(this HttpResponseMessage response)
    	{
    		return response.FirstContentTypeTypes().Contains("application/json");
    	}
    
    	public static IEnumerable<string> FirstContentTypeTypes(
    	    this HttpResponseMessage response)
    	{
    		IEnumerable<string> contentTypes =
    		     response.Content.Headers.Single(h => h.Key == "Content-Type").Value;
    
    		return contentTypes.First().Split(new string[] { "; " }, StringSplitOptions.None);
    	}
    }
