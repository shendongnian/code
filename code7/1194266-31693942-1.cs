    void YourMethod()
    {
        string url2 = Sites[i].ToString();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url2));
        HttpWebResponse response;
        string errorMessage;
        var gotResponse = TryGetResponse(request, out response, out errorMessage); // This is now a safe call
        if (!gotResponse || response.StatusCode != HttpStatusCode.OK)
        {
            // Send mail and use errorMessage
        }
    }
    private static bool TryGetResponse(HttpWebRequest request, out HttpWebResponse response, out string errorMessage)
    {
        errorMessage = null; 
        try
        {
            response = (HttpWebResponse)request.GetResponse();
            // Everything ok, if we get here
            return true;
        }
        catch (WebException e)
        {
            if (e.Response == null)
            {
                response = null;
                if (e.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    errorMessage = "Name resolution failed.";
                }
                return false;
            }
            response = (HttpWebResponse)e.Response;
            return true;
        }
    }
