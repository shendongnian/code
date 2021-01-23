    private string ReconnectFritzBox()
    {
        string xmldata = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
        "<s:Envelope s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope\">" +
            "<s:Body>" +
                "<u:ForceTermination xmlns:u=\"urn:schemas-upnp-org:service:WANIPConnection:1\" />" +
            "</s:Body>" +
        "</s:Envelope>";
    
        string resulXmlFromWebService = null;
    
        var webRequest = WebRequest.Create("http://fritz.box:49000/igdupnp/control/WANIPConn1");
        var httpRequest = (HttpWebRequest)webRequest;
        httpRequest.Method = "POST";
        httpRequest.ContentType = "text/xml; charset=utf-8";
        httpRequest.Headers.Add("SOAPACTION", "urn:schemas-upnp-org:service:WANIPConnection:1#ForceTermination");
        httpRequest.ProtocolVersion = HttpVersion.Version11;
        httpRequest.Credentials = CredentialCache.DefaultCredentials;
        httpRequest.ContentLength = xmldata.Length;
    
        using (var requestStream = httpRequest.GetRequestStream())
        {
            //Create Stream and Complete Request             
            using (var streamWriter = new StreamWriter(requestStream, Encoding.ASCII))
            {
                streamWriter.Write(xmldata);
                streamWriter.Close();
    
                //Get the Response    
                var wr = (HttpWebResponse)httpRequest.GetResponse();
                using (var srd = new StreamReader(wr.GetResponseStream()))
                {
                    resulXmlFromWebService = srd.ReadToEnd();
                }
            }
        }
    
        return resulXmlFromWebService;
    }
