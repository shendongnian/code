    [XmlType("Outer_X")]
    public class Outer
    {
        public Outer()
        {
            this.InnerItem = new Inner();
        }
        [XmlIgnore]
        public Inner InnerItem { get; set; }
        [XmlElement(typeof(Inner))]
        [XmlElement(typeof(object))]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public object InnerItemXmlProxy
        {
            get
            {
                return InnerItem;
            }
            set
            {
                InnerItem = (Inner)value;
            }
        }
    }
