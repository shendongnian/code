    public static string GetStsToken(string relyingPartyUri)
    {
        string result = null;
        string samlHttpPostUri = string.Format(
            "https://<ADFS-SERVER>/adfs/ls/idpinitiatedsignon.aspx?loginToRp={0}",
            relyingPartyUri
        );
        WebRequest req = WebRequest.Create(samlHttpPostUri);
        req.Method = WebRequestMethods.Http.Get;
        req.Credentials = CredentialCache.DefaultNetworkCredentials;
        XDocument xDoc = null;
        try
        {
            using (WebResponse resp = req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    string htmlResult = reader.ReadToEnd();
                    xDoc = XDocument.Parse(htmlResult);
                    string samlResponseBase64 = (from xElement in xDoc.Descendants()
                                                 where xElement.Name == "input" &&
                                                       xElement.Attribute("name").Value == "SAMLResponse"
                                                 select xElement.Attribute("value").Value).FirstOrDefault();
                    result = System.Text.Encoding.UTF8.GetString(
                        Convert.FromBase64String(samlResponseBase64)
                    );
                }
            }
        }
        catch (WebException webExc)
        {
            using (StreamReader reader = new StreamReader(webExc.Response.GetResponseStream()))
            {
                // THE EXCEPTION IS REGISTERED
            }
        }
        return result;
    }
