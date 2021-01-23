    public static string Connect(string Uri)
    {
       HttpWebRequest connection = WebRequest.Create(requestURI) as HttpWebRequest;
        connection.Method = "GET";
        string response;
        HttpWebResponse response = null;
        try
        {
            response = request.GetResponse() as HttpWebResponse
        }
        catch (WebException ex)
        {
            response = ex.Response;
        }
        
        using (response)    
        using (var responseStream = new StreamReader(response.GetResponseStream()))
        {
            responseText = responseStream.ReadToEnd();
        }
        return response;
    }    
