    private string RestRequest(string URL, RestSharp.Method Method)
    {
        var Client = new RestClient();
        Client.Authenticator = new HttpBasicAuthenticator(ID, Password);
        
        string requestUrl;
        bool hasBackslashArgument = ParseEncodedBackSlash(URL, out requestURL);
        if(!hasBackslashArgument)
        {
            requestUrl = URL;
        }
        var Request = new RestRequest(requestUrl, Method);
        
		if(hasBackslashArgument)
        {
		    Request.AddUrlSegment("segment", "%2F");
		}
        
        IRestResponse Response = Client.Execute(Request);
        return Response.Content;
    }
    private bool ParseEncodedBackSlash(string url, out preformattedString)
    {
         var urlSegments = url.Split("%2F");
         if(urlSegments.Length == 0) return false;
         preformattedString = string.Join("{segment}",urlSegments);
         return true;
    }
