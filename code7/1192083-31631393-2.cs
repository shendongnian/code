    public static class NodeExtensions
    {
        public static TData [] ToDataArray<TData>(this IEnumerable<Node<TData>> nodes)
        {
            if (nodes == null)
                return null;
            return nodes.Select(n => n.Data).ToArray();
        }
    }
    public class ProfileObject
    {
        public Person Person { get; set; }
        [XmlIgnore]
        public IEnumerable<Node<Language>> Language { get; set; }
        [XmlIgnore]
        public IEnumerable<Node<Country>> Country { get; set; }
        [XmlArray("ArrayOfLanguage")]
        [XmlArrayItem("Language")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Language [] LanguageArray
        {
            get
            {
                return Language.ToDataArray();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        [XmlArray("ArrayOfCountry")]
        [XmlArrayItem("Country")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Country [] CountryArray
        {
            get
            {
                return Country.ToDataArray();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
