    public static class XmlSanitizer
    {
        static XNamespace NS => "urn:example:sanitizer";
        internal static XName IndexName => NS + "Index";
        internal static XName SanitizedName => NS + "Sanitized";
        public static void Sanitize(XDocument doc, params string[] patterns)
        {
            if (!HasSanitzerNamespace(doc))
                doc.Root.Add(new XAttribute(XNamespace.Xmlns + "s", NS.NamespaceName));
            
            foreach (var pattern in patterns)
            {
                var nodes =
                    (from e in doc.Root.Elements()
                    let m = Regex.Match(e.Name.LocalName, pattern)
                    where m.Success
                    let sanitized = (bool?)e.Attribute(SanitizedName)
                    where !(sanitized ?? false)
                    select new
                    {
                        Element = e,
                        Namespace = e.Name.Namespace,
                        LocalName = m.Groups[1].Value,
                        Index = m.Groups[2].Value,
                    }).ToList();
                foreach (var x in nodes)
                {
                    // it might be preferrable to place the new elements within a grouping element
                    x.Element.ReplaceWith(
                        new XElement(x.Namespace + x.LocalName,
                            new XAttribute(IndexName, x.Index),
                            new XAttribute(SanitizedName, true),
                            x.Element.Attributes(),
                            x.Element.Nodes()
                        )
                    );
                }
            }
        }
        
        static bool HasSanitzerNamespace(XDocument doc) =>
            (from a in doc.Root.Attributes()
            where a.Name.Namespace == XNamespace.Xmlns
            where (string)a == NS.NamespaceName
            select a).Any();
    }
    
    public static class XmlStanitizerExtensions
    {
        static XName IndexName => XmlSanitizer.IndexName;
        public static XElement ElementIndex(this XElement e, XName name, string index) => e.Elements(name).Where(n => (string)n.Attribute(IndexName) == index).Single();
    }
