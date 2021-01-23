    [XmlRoot(Namespace = JobInput.XmlNamespace)]
    [XmlType(Namespace = JobInput.XmlNamespace)]
    public class JobInput
    {
        const string XmlNamespace = "";
        public int AgencyId { get; set; }
        public Guid ExternalId { get; set; }
        public string Requester { get; set; }
        
        [XmlIgnore]
        public IInput Input { get; set; }
        [XmlAnyElement]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XElement[] XmlCustomElements
        {
            get
            {
                var list = new List<XElement>();
                if (Input != null)
                    list.Add(Input.SerializePolymorphicToXElement(XName.Get("Input", XmlNamespace)));
                // Add others as needed.
                return list.ToArray();
            }
            set
            {
                if (value == null)
                    return;
                this.Input = value.DeserializePolymorphicEntry<IInput>(XName.Get("Input", XmlNamespace));
                // Add others as needed.
            }
        }
    }
