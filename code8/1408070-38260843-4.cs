    XmlDocument constDocument = new XmlDocument();
    constDocument.CreateComment(" Consts section generated on {DateTime.Now} ");
    constDocument.CreateComment(" First group of constants. ");
    FirstTextConsts(MyFirstCollection); // Need to be adapted
    constDocument.CreateComment(" Refrigerant constants. ");
    SecondTextConsts(MySecondCollection); // Need to be adapted
    
    StringBuilder sb = new StringBuilder();
    XmlWriterSettings xws = new XmlWriterSettings
    {
        ConformanceLevel = ConformanceLevel.Fragment,
        OmitXmlDeclaration = true,
        Indent = true
    };
    using (XmlWriter xw = XmlWriter.Create(sb, xws))
    {
        constDocument.Save(xw);
    }
    System.IO.StreamWriter file = new System.IO.StreamWriter(_outputFileName);
    file.WriteLine(sb.ToString()); 
    file.Close();
