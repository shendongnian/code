    var xmlDocument = new XmlDocument();
    
    //create XmlReaderSettings first
    var settings = new XmlReaderSettings();
    settings.MaxCharactersFromEntities = 0;
    
    //create XmlReader later, passing the pre-defined settings
    var xmlReader = XmlReader.Create(fileInfo.FullName, settings);
    
    //the rest of the codes remain untouched
    var vr = new XmlValidatingReader(xmlReader);
    vr.ValidationType = ValidationType.None;
    vr.EntityHandling = EntityHandling.ExpandEntities;
    
    xmlDocument.Load(vr);
