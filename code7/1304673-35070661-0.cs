    private static HttpWebRequest CreateWebRequest(SoapAction action)
    {
        string url = GetUrlAddress(action);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
        request.Headers.Add(HttpRequestHeader.ContentEncoding, "gzip"); 
        request.Headers.Add("SOAPAction", action.ToString());
        request.ContentType = "application/xop+xml";
        request.Accept = "text/xml";
        request.Method = "POST";
        request.ClientCertificates.Add(/* Retrieve X509Certificate Object*/);
        return request;
    }
