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
                return XmlKeyValueListHelper.SerializeAttributeNameValueList(Parameters, "name");
            }
            set
            {
                Parameters = XmlKeyValueListHelper.DeserializeAttributeNameValueList<Parameter>(value, "name");
            }
        }
    }
