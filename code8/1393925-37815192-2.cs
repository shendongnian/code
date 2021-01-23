    private static void SplitXmlFile(string sourceFile
                        , string rootElement
                        , string descendantElement
                        , int takeElements
                        , string destFilePrefix
                        , string destPath)
    { 
        XElement xml = XElement.Load(sourceFile);
        XNamespace ns = "http://services.hpd.gov"; // This line must be added.
        xml = xml.Element(ns + rootElement); // rootElement must be "Registrations". And also this line must be added.
        // Child elements from source file to split by.
        var childNodes = xml.Descendants(ns + descendantElement);
    .....
    .....
