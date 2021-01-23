    public class MyWebRequest 
    {
    	public HttpWebResponse Request(string url)
    	{
    		HttpWebResponse response = null;
    		try
    		{
    			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
    			response = (HttpWebResponse)httpWebRequest.GetResponse();
    		}
    		catch (WebException ex)
    		{
    			// Handle exception
    		}
    		return response;
    	}
    }
