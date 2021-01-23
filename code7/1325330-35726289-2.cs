    HttpWebRequest request = WebRequest.Create(requestURI) as HttpWebRequest;
    string text;
    HttpStatusCode status;
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    using (var responseStream = new StreamReader(response.GetResponseStream()))
    {
       text = responseStream.ReadToEnd();
       status = response.StatusCode;
    }
    
