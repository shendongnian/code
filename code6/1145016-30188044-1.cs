    [HttpPost]
    public HttpResponseMessage getClassXml(HttpRequestMessage req)
    {
        
         ...
       
         XmlTextReader reader = new XmlTextReader(AppDomain.CurrentDomain.BaseDirectory + "Resource\\" + percorso);
         reader.Read();
         doc.Load(reader);
    
         HttpResponseMessage response = new HttpResponseMessage { Content = new StringContent(doc.innerXml, Encoding.UTF8,"application/xml") };
         return response;
    }
    
