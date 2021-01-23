    public void LoadXML()
    {
        HttpClient client = new HttpClient();
        var httpResponseMessage = await client.GetAsync(new Uri("http://thewindev.net/post-sitemap.xml"));
        if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
        {
            var xmlStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            XDocument xml = XDocument.Load(xmlStream);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml.ToString());
        }
    }
