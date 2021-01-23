    [DataContract(Name = "Vorgang")]
    [KnownType(typeof(Vorgang))]
    public class Vorgang
    {
        [XmlIgnore]  // use XmlIgnore instead IgnoreDataMember
        public DateTime Vertragsbeginn { get; set; }
    }
    // this class map all elements from the xml that you show
    [XmlRoot("Vorgang")]  // to map the Xml Vorgang as a VorgangOverride instance
    public class VorgangOverride : Vorgang
    {
        [XmlAttribute("Vorgang2")]  // to map the Vorgang attribute
        public string VorgangAttribute { get; set; }
        [XmlElement(ElementName = "Vertragsbeginn")]  // to map the Vertragsbeginn element
        public Vertragsbeginn VertragsbeginnElement
        {
            get { return _vertragsbeginn; }
            set
            {
                base.Vertragsbeginn = new DateTime();  // here I Assing the correct value to the DateTime property on Vorgan class.
                _vertragsbeginn = value;
            }
        }
        private Vertragsbeginn _vertragsbeginn;
    }
    // this class is used to map the Vertragsbeginn element
    public class Vertragsbeginn
    {
        [XmlAttribute("Vertragsbeginn")]  // to map the Vertragsbeginn attriubute on the Vertragsbeginn element
        public string VertragsbeginnAttribute { get; set; }
    }
