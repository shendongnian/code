    xmlDocument = new XmlDocument();
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.MaxCharactersFromEntities = 0;
    XmlReader reader = XmlReader.Create(fileInfo.FullName, settings);
    var vr = new XmlValidatingReader(reader);
    vr.ValidationType = ValidationType.None;
    vr.EntityHandling = EntityHandling.ExpandEntities;
    xmlDocument.Load(vr);
