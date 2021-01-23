    static XDocument MergeResxFiles(string[] files)
    {
        var allResources =
            from f in files
            let doc = XDocument.Load(f)
            from e in doc.Root.Elements("data")
            select Resource.Parse(e, f);
    
        var elements = new List<XElement>();
        foreach (var g in allResources.GroupBy(r => r.Name))
        {
            elements.AddRange(MergeResources(g.Key, g));
        }
        var output = new XDocument(new XElement("root", elements));
        return output;
    }
    
    private static IEnumerable<XElement> MergeResources(string name, IEnumerable<Resource> resources)
    {
        var grouped = resources.GroupBy(r => r.Value).ToList();
        if (grouped.Count == 1)
        {
            yield return grouped[0].First().Xml;
        }
        else
        {
            Console.WriteLine($"Duplicate entries for {name}");
            foreach (var g in grouped)
            {
                var comments = g.Select(r => new XComment($"Source: {r.FileName}"));
                yield return new XElement(
                    "data",
                    comments,
                    new XAttribute("name", name),
                    new XElement("value", g.Key));
            }
        }
    }
    
    class Resource
    {
        public string Name { get; }
        public string Value { get; }
        public string FileName { get; }
        public XElement Xml { get; }
    
        public Resource(string name, string value, string fileName, XElement xml)
        {
            Name = name;
            Value = value;
            FileName = fileName;
            Xml = xml;
        }
    
        public static Resource Parse(XElement element, string fileName)
        {
            string name = element.Attribute("name").Value;
            string value = element.Element("value").Value;
            return new Resource(name, value, fileName, element);
        }
    }
