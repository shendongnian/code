    XDocument xmlDoc = new XDocument();
    var sr = new System.IO.StreamReader(response.GetResponseStream())
    xmlDoc = XDocument.Parse(sr.ReadToEnd());
    
    var strCountry = xmlDoc.Root.Element("Country");
