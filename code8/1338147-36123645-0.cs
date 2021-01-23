    public class OuterElem
    {
        [XmlElement(typeof(C1))]
        [XmlElement(typeof(C2))]
        public object[] InnerElem { get; set; }
    }
