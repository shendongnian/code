    private XmlDocument GetRootLevelServiceDocument(
    string serviceEndPoint, string oAuthToken)
    {
    XmlDocument xmlDoc = new XmlDocument();
    HttpWebRequest request = CreateHttpRequest(serviceEndPoint, 
        oAuthToken);
 
    using (HttpWebResponse response = 
        (HttpWebResponse)request.GetResponse())
    {
        using (XmlReader reader = 
            XmlReader.Create(response.GetResponseStream(), 
            new XmlReaderSettings() { CloseInput = true }))
        {
            xmlDoc.Load(reader);
            string data = ReadResponse(response);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                LogMsg(string.Format("Error: {0}", data));
                LogMsg(string.Format(
                    "Unexpected status code returned: {0}", 
                    response.StatusCode));
            }
        }
    }
    return xmlDoc;
    }
