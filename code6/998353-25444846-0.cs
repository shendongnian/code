    public void Delete(string ID)
    {
        XDocument xml = XDocument.Load(xmlPath);
    
        xml.Descendants("Photo")
                .Where(e => e.Attribute("UID") != null && (string)e.Attribute("UID").Value == ID)
                .Remove();
    }
