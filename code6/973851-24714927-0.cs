    XNamespace ns = XNamespace.Get("urn:uiosp-bundle-manifest-2.0");
    XDocument ManifestDocument = XDocument.Load(@"myxml.xml");
    string widgetCodeName = ManifestDocument.Root.Attribute("SymbolicName").Value;
    
    string path;
    var assemplyElement = ManifestDocument.Descendants(ns + "Assembly").FirstOrDefault();
    if (assemplyElement != null)
    {
        path = (string)assemplyElement.Attribute("Path");
    }
