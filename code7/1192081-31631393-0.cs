    public class ProfileObject
    {
        public Person Person { get; set; }
        [XmlIgnore]
        public IEnumerable<Node<Language>> Language { get; set; }
        [XmlIgnore]
        public IEnumerable<Node<Country>> Country { get; set; }
        [XmlArray("Languages")]
        [XmlArrayItem("Language")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Node<Language>[] LanguageArray
        {
            get
            {
                if (Language == null)
                    return null;
                return Language.ToArray();
            }
            set
            {
                Language = value;
            }
        }
        [XmlArray("Countries")]
        [XmlArrayItem("Country")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Node<Country>[] CountryArray
        {
            get
            {
                if (Country == null)
                    return null;
                return Country.ToArray();
            }
            set
            {
                Country = value;
            }
        }
    }
