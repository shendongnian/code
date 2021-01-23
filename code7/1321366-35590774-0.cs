    public static void ConvertStringToXmlList()
    {
        XElement xml = new XElement
            (
                "Items",
                (
                    from x in [YourList] select new XElement("Item", x)
                )
            );
        XDocument doc = new XDocument
            (
                xml
            );
        doc.Save(Environment.CurrentDirectory + "/settings.xml");  
    }
 
    var xmlReader = new XmlTextReader("settings.xml");
    while (xmlReader.Read()) 
    {
        switch (reader.NodeType) 
        {
           case [nodetype]:
               // Code here
           break;
        }
    }
