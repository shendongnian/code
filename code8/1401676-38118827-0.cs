    <%@ Page Language="C#" Debug="true" %>
    <%@ Import Namespace="System.Net" %>
    <%@ Import Namespace="System.IO" %>
    <%
    // The service we wish to consume
    string uri = "http://eu9992k8dvweb01.emea.world.net/DEV/api/1.5.12077.001/en-GB/8/56/Incident/GetList?StartIndex=0&PageLength=10";
    //Create web request
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);  
    //Create credential cache
    CredentialCache myCredCache = new CredentialCache();
    myCredCache.Add(new Uri(uri), "Negotiate", (NetworkCredential)CredentialCache.DefaultCredentials);
    //Add credentials to web request
    req.Credentials = myCredCache;
    req.Proxy = null;
    // create somewhere for the response to go
    HttpWebResponse httpResponse = null;
    // now use the request
    try
    {
    	// get the requested page
    	httpResponse = (HttpWebResponse)req.GetResponse();
    	// output what was returned
    	using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
    	{
    		Response.Write(streamReader.ReadToEnd());
    	}
    }
    finally
    {
    	// close the response object
    	if (httpResponse != null)
    		httpResponse.Close();
    }
    %>
