    public class Element
    {
        [XmlAttribute]
        public type1 attributeX { get; set; }
        
        [XmlAttribute]
        public type1 attributeY { get; set; }
        [XmlIgnore]
        public bool attributeYSpecified { get { return attributeY != null; } set { } }
        
        [XmlAttribute]
        public type1 attributeZ { get; set; }
        [XmlIgnore]
        public bool attributeZSpecified { get { return attributeZ != null; } set { } }
        
        [XmlChoiceIdentifier("ElementTypes")]
        [XmlElement("Element", typeof(Element))]
        [XmlElement("SubElement", typeof(Element))]
        public Element[] Elements { get; set; }
        
        [XmlIgnore]
        public ElementType[] ElementTypes
        {
            get
            {
                return Elements
                    .Select(el => (el.attributeYSpecified && !el.attributeZSpecified) ?
                                  ElementType.Element :
                                  (!el.attributeYSpecified && el.attributeZSpecified) ?
                                  ElementType.SubElement :
                                  ElementType.None)
                    .ToArray();
            }
            set
            {
            }
        }
    }
    
    public enum ElementType
    {
        None,
        Element,
        SubElement
    }
