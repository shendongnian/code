    HttpWebRequest request = WebRequest.Create(requestURI) as HttpWebRequest;
    string text;
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    using (var responseStream = new StreamReader(response.GetResponseStream()))
    {
       text = responseStream.ReadToEnd();
       var status = response.StatusCode;
    }
    
