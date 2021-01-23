    private string SerializeToString(object data)
    {
        if (data == null) return null;
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");
    
        // what should the XmlWriter do?
        var settings = new XmlWriterSettings
        {
            OmitXmlDeclaration = true,
            NewLineChars = ""
        };
        
        using (var stringwriter = new System.IO.StringWriter())
        {
           // Use an XmlWriter to wrap the StringWriter
           using(var xmlWriter = XmlWriter.Create(stringwriter, settings))
           {
               var serializer = new XmlSerializer(data.GetType(), "");
               // serialize to the XmlWriter instance
               serializer.Serialize(xmlWriter, data, ns);
               return stringwriter.ToString();
           }
        }
    }
