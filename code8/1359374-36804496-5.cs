    [XmlType(Outer.XmlTypeName)]
    public class Outer
    {
        public const string XmlTypeName = "Outer_X";
        public Outer()
        {
            this.InnerItem = new Inner();
        }
        [XmlElement(Inner.XmlTypeName)]
        public Inner InnerItem { get; set; }
    }
    [XmlType(Inner.XmlTypeName)]
    public class Inner
    {
        public const string XmlTypeName = "Inner_X";
    }
