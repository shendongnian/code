    public class Error
    {
        [XmlElement("message")]
        public string Message { get; set; }
        Dictionary<string, string> keys;
        [XmlIgnore]
        public Dictionary<string, string> Keys
        {
            get
            {
                // Ensure keys is never null.
                return (keys = keys ?? new Dictionary<string, string>());
            }
            set
            {
                keys = value;
            }
        }
        [XmlElement("keys")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XmlKeyTextValueListWrapper<string> XmlKeys
        {
            get
            {
                return new XmlKeyTextValueListWrapper<string>(() => this.Keys);
            }
            set
            {
                value.CopyTo(Keys);
            }
        }
    }
