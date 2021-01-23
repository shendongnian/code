    // Name of the attributes we are looking
    string ns = "http://schemas.microsoft.com/netfx/2010/xaml/activities/presentation";
    XName name = XName.Get("Annotation.AnnotationText", ns);
    
    
    XDocument doc = XDocument.Load("XMLFile1.xml");
    
    var q = doc.Descendants().Where(e => e.Attribute(name) != null)
        .Select(e => new DictionaryEntry { Key = e.Attribute("ID").Value, Value = e.Attribute(name).Value });
