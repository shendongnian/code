    void XmlSchemaEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Error)
            throw new XmlException(e.Message);
        else if (e.Severity == XmlSeverityType.Warning)
            Logger.Info(e.Message);
    }
    void XmlValidationEventHandler(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Error)
            throw new XmlException(e.Message);
        else if (e.Severity == XmlSeverityType.Warning)
            throw new XmlException(e.Message);
    }
