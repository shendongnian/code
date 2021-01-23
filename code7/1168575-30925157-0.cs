    [XmlType(Namespace = "http://www.w3.org/2005/Atom")]
    public class FamilyType
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlIgnore]
        public Parameter[] Parameters { get; set; }
        [XmlAnyElement]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XElement[] XmlParameters
        {
            get
            {
                if (Parameters == null)
                    return null;
                var ns = new XmlSerializerNamespaces();
                ns.Add("", typeof(Parameter).RootXmlElementNamespace());
                var query = Parameters
                    .Select(p => p.SerializeToXElement(ns))
                    .Select(e =>
                    {
                        var attr = e.Attribute("name");
                        e.Name = e.Name.Namespace + XmlConvert.EncodeLocalName((string)attr);
                        attr.Remove();
                        return e;
                    });
                return query.ToArray();
            }
            set
            {
                if (value == null)
                {
                    Parameters = null;
                    return;
                }
                var query = value
                    .Select(e => new XElement(e)) // Do not modify the input values.
                    .Select(e => { 
                        e.Add(new XAttribute("name", XmlConvert.DecodeName(e.Name.LocalName)));
                        e.Name = e.Name.Namespace + typeof(Parameter).RootXmlElementName();
                        return e; 
                    })
                    .Select(e => e.Deserialize<Parameter>());
                Parameters = query.ToArray();
            }
        }
    }
