    [XmlRoot(ElementName = "Outer_X")]
    public class Outer
    {    
        [XmlElement(ElementName = "Inner_X")]
        public Inner InnerItem { get; set; } = new Inner();
    }
    
    public class Inner { }
