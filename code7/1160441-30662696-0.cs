    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ResultSet
    {
        private ResultSetResult[] resultField;
        [System.Xml.Serialization.XmlElementAttribute("Result")]
        public ResultSetResult[] Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
       }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResultSetResult
    {
        private decimal latitudeField;
        private string precisionField;
        public decimal Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
               this.latitudeField = value;
            }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string precision
        {
            get
            {
                return this.precisionField;
            }
            set
            {
                this.precisionField = value;
            }
        }
    }
