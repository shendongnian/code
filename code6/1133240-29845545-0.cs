    public class HtmlWebExtended : HtmlWeb
    {
    	public HtmlDocument SubmitFormValues(NameValueCollection fv, string url)
    	{
    		// Attach a temporary delegate to handle attaching
    		// the post back data
    		......
    	}
    
    	private string AssemblePostPayload(NameValueCollection fv)
    	{
    		......
    	}
    }
