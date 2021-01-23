    var xml = XDocument.Load(@"C:\tmp\test.xml");
    string version = xml.Root.Attribute("version").Value;
    string space = "http://www.rdlt.org";
    var obj = new Container()
    {
        created = DateTime.Parse(xml.Root.Element(XName.Get("created", space)).Value),
        updated = DateTime.Parse(xml.Root.Element(XName.Get("updated", space)).Value),
    };
