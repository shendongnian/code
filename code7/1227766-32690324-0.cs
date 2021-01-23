    XmlReaderSettings settings = new XmlReaderSettings();
    // SET THE RESOLVER
    settings.XmlResolver = new XmlUrlResolver();
    settings.ValidationType = ValidationType.DTD;
    settings.DtdProcessing = DtdProcessing.Parse;
    settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
    settings.IgnoreWhitespace = true;
