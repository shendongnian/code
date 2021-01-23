    XDocument xDoc = XDocument.Load("File Path");
    IEnumerable<XElement> xmlData = xDoc.Descendants("node name");
    foreach(XElement element in xmlData)
    {
       if(element == null)
       {
           continue;
       }
       // retrieve key using element.Attribute("name").Value
       // retrieve value using element.Element("value").Value
     }
