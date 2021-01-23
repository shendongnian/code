    public class testTag01 
    {
        [XmlAttribute]
        public string NV { get; set; }
        [XmlAttribute("nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get { return "true"; } set { } }
    }
