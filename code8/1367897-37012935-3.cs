    XNamespace elementNamespace = "MyApp_ConfigurationFiles";
    var elementName = elementNamespace + "TestConfiguration";
    
    try
    {
        var xsdDocument = XDocument.Load(xsdFilePath);
        var schemaSet = new XmlSchemaSet();
        using (var xsdReader = xsdDocument.CreateReader())
            schemaSet.Add(XmlSchema.Read(xsdReader, this.XmlSchemaEventHandler));
        var xmlDocument = XDocument.Load(xmlFile);
    
        var element = xmlDocument.Root.Element(elementName);
        element.Validate(schemaSet, XmlSchemaValidationFlags.ReportValidationWarnings, this.XmlValidationEventHandler);
    }
    catch (Exception e)
    {
        Logger.Info(string.Format("Error validating element {0} of XML file: {1}", elementName, xmlFile));
        throw new Exception(e.Message);
    }
