    XmlDocument doc = new XmlDocument() ;
    doc.load(xmlFileName) ;
    doc.Schemas.Add("",xsdFileName);
    doc.Schemas.Compile();
    TheSchemaErrors   = new List<string>() ;
    TheSchemaWarnings = new List<string>() ;
    doc.Validate(Xml_ValidationEventHandler);
    if (TheSchemaErrors  .Count>0) { // display errors  }
    if (TheSchemaWarnings.Count>0) { // display warnings  }
    ...
    private List<string> TheSchemaErrors ;
    private List<string> TheSchemaWarnings ;
    private void Xml_ValidationEventHandler(object sender,ValidationEventArgs e)
    {
      switch (e.Severity)
      {
        case XmlSeverityType.Error   : TheSchemaErrors  .Add(e.Message) ; break;
        case XmlSeverityType.Warning : TheSchemaWarnings.Add(e.Message) ; break;
      }
    }
