    public class Error
    {
        [XmlElement("message")]
        public string Message { get; set; }
        List<KeyValuePair<string, string>> keys;
        [XmlIgnore]
        public List<KeyValuePair<string, string>> Keys
        {
            get
            {
                // Ensure keys is never null.
                return (keys = keys ?? new List<KeyValuePair<string, string>>());
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
                Keys.ClearAndAddRange(value);
            }
        }
    }
