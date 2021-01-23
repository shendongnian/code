    /// <summary>
    /// Request Form Digest value
    /// </summary>
    /// <returns></returns>
    private string GetFormDigest()
    {
        var endpoint = "/_api/contextinfo";
        var request = (HttpWebRequest) WebRequest.Create(_host.AbsoluteUri + endpoint);
        request.CookieContainer = new CookieContainer();
        request.Method = "POST";
        //request.Accept = "application/json;odata=verbose";
        request.ContentLength = 0;
        using (var response = (HttpWebResponse)request.GetResponse())
        {
             using (var reader = new StreamReader(response.GetResponseStream()))
             {
                 var result = reader.ReadToEnd();
                   
                 // parse the ContextInfo response
                 var resultXml = XDocument.Parse(result);
                 // get the form digest value
                 var e = from e in resultXml.Descendants()
                                     where e.Name == XName.Get("FormDigestValue", "http://schemas.microsoft.com/ado/2007/08/dataservices")
                                select e;
                 _formDigest = e.First().Value;   
             }
        }
        return _formDigest;
    }
 
