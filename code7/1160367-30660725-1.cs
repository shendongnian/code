    var xmlDocument = new XmlDocument();
    
    //create XmlReaderSettings first
    var settings = new XmlReaderSettings();
    settings.MaxCharactersFromEntities = 80; //0 doesn't make sense here, as it's the default value
    
    //create XmlReader later, passing the pre-defined settings
    var xmlReader = XmlReader.Create(fileInfo.FullName, settings);
    
    //the rest of the codes remain untouched
    var vr = new XmlValidatingReader(xmlReader);
    vr.ValidationType = ValidationType.None;
    vr.EntityHandling = EntityHandling.ExpandEntities;
    
    xmlDocument.Load(vr);
