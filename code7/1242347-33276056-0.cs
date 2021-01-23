    using (WebClient webClient = new WebClient())
    {
        string email = loginDialog.email;
        string password = loginDialog.password;
    
                                   
    
        webClient.Headers.Add("Content-Type", "application/json");
        webClient.Headers.Add("OSLC-Core-Version", "2.0");
    
        //Windows login: Email + Password
        webClient.Credentials = new NetworkCredential(email, password);
        using (Stream stream = webClient.OpenRead(URLstring)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            string json = JsonConvert.SerializeXmlNode(doc);
    
            JObject searchResult = JObject.Parse(json);
            if (searchResult.GetValue("oslc_cm:totalCount").Value<int>() == 1) {
            using (Stream BTQStream = webClient.OpenRead(searchResult.SelectToken("oslc_cm:results").First.SelectToken("rdf:resource").Value<String>()))
            {
               XmlDocument BTQdoc = new XmlDocument();
               BTQdoc.Load(BTQStream);
               string BTQJson = JsonConvert.SerializeXmlNode(BTQdoc);
               JObject BTQEntry = JObject.Parse(BTQJson);
               priority = BTQEntry.SelectToken("Severity.oslc_cm:label").Value<String>();
               BTQStatus = BTQEntry.GetValue("State").Value<String>();
               implementationDate = Convert.ToDateTime(BTQEntry.GetValue("actualdate_impl").Value<String>());
            }
            }
        }
