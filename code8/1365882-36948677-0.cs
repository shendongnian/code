    public partial class DateOfDeath
    {
        private NilReason nilReasonField;
        private bool nilReasonFieldSpecified;
        private System.DateTime valueField;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public NilReason nilReason
        {
            get/set...
        }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nilReasonSpecified
        {
            get/set...
        }
        [System.Xml.Serialization.XmlText(DataType = "date")]
        public System.DateTime Value
        {
            get/set...
        }
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    public enum NilReason
    {
        noValue,
        valueUnknown,
    }
