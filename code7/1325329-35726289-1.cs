    HttpWebRequest request = WebRequest.Create(requestURI) as HttpWebRequest;
    string text;
    HttpReturnStatus status;  //not sure of the type, might be int, or some enum.
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    using (var responseStream = new StreamReader(response.GetResponseStream()))
    {
       text = responseStream.ReadToEnd();
       status = response.StatusCode;
    }
    
