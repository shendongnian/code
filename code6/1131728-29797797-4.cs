    [DataContract(Name = "Vorgang")]
    [KnownType(typeof(Vorgang))]
    public class Vorgang
    {
        [IgnoreDataMember]
        public DateTime Vertragsbeginn { get; set; }
    }
    [XmlRoot("Vorgang")]  // change this
    public class VorgangOverride : Vorgang
    {
        private string datestring;
        [XmlAttribute("Vertragsbeginn")]
        public string VertragsbeginnAsString  // change this
        {
            get { return datestring; }
            set
            {
                base.Vertragsbeginn = DateUtil.StringToDate(value, EDIEnums.Vertragsbeginn);
                datestring = value;
            }
        }
    }
