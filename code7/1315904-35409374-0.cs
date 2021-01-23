    using System.IO.Packaging;
        
    var package = Package.Open(ms, FileMode.Open, FileAccess.ReadWrite);
    var corePart = package.GetPart(new Uri("/docProps/core.xml", UriKind.Relative))
    XDocument settings;
    using (TextReader tr = new StreamReader(settingsPart.GetStream()))
        settings = XDocument.Load(tr);
                        
    XNamespace cp = "http://schemas.openxmlformats.org/package/2006/metadata/core-properties"
    var tags = settings.Root.Element(cp + "keywords");
