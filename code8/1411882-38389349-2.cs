    [XmlType(AnonymousType = true)]
    public class FSAMarketsFeedMsg
    {
        [XmlIgnore]
        public CoreItemsMkt CoreMarket { get; set; }
        [XmlAnyElement(Name = "CoreItemsMkt", Namespace = Namespaces.FSAMarketsFeed)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XElement CoreMarketXml
        {
            get
            {
                return (CoreMarket == null ? null : XObjectExtensions.SerializeToXElement(CoreMarket, 
                    XmlSerializerFactory.Create(typeof(CoreItemsMkt), "CoreItemsMkt", Namespaces.FSAMarketsFeed), 
                    Namespaces.GetFSAMarketsFeedNamespace()));
            }
            set
            {
                CoreMarket = (value == null ? null : XObjectExtensions.Deserialize<CoreItemsMkt>(value, 
                    XmlSerializerFactory.Create(typeof(CoreItemsMkt), "CoreItemsMkt", Namespaces.FSAMarketsFeed)));
            }
        }
        // Remainder of properties are left unchanged.
    }
