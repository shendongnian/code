    var xdoc = XDocument.Load(filename);
    var engine = xdoc.Root.Descendants("Engine").FirstOrDefault();
    if (engine != null)
    {
        engine.Add(new XElement("Host", 
            new XAttribute("name", "url"),
            new XElement("Valve",
                new XAttribute("className", "org.apache.catalina.valves.AccessLogValve"))));
        xdoc.Save(filename);
    }
