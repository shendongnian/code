    public XmlDocument GetApplicationEntity(string serviceURL, string appToken, string appCode, string entityCode, string userName)
    {
        try
        {
            string requestUrl = string.Format("{0}/GetApplicationEntity/{1}/{2}/{3}/{4}", serviceURL, appToken, appCode, entityCode, userName);
    
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
            request.Method = "GET";
    
            using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(reader.ReadToEnd());
    
                return doc;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
