    [XmlType("Outer_X")]
    public class Outer
    {
        public Outer()
        {
            this.InnerItem = new Inner();
        }
        [XmlElement("Inner_X")]
        public Inner InnerItem { get; set; }
    }
    public class Inner
    {
    }
