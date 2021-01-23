    XmlElement fishElement = doc.CreateElement(string.Empty, "fi", string.Empty);
    IEnumerable<XmlAttribute> attCollection = AddExtraAttributes(doc,condition);
    foreach (XmlAttribute attribute in attCollection)
       {
          fishElement.Attributes.Append(attribute);
       }
    
    private IEnumerable<XmlAttribute> AddExtraAttributes(XmlDocument doc,bool condition)
    {
        List<XmlAttribute> xmlAttributeCollection = new List<XmlAttribute>();
        if(condition)
         {
            XmlAttribute attribute = doc.CreateAttribute("A");
            attribute.Value = "value1";
            xmlAttributeCollection.Add(attribute);
         }
        else
         {
            XmlAttribute attribute = doc.CreateAttribute("B");
            attribute.Value = "value2";
            xmlAttributeCollection.Add(attribute);
         }
       return xmlAttributeCollection;
    }
