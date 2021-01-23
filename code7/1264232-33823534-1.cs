    string xmlAsString;
    using (var xmlWebClient = new WebClient())
                {
                    xmlWebClient.Encoding = Encoding.UTF8;
                    xmlAsString = xmlWebClient.DownloadString(url);
                }
    XmlDocument currentXml = new XmlDocument();
    currentXml.Load(xmlAsString);
