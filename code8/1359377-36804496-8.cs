    [XmlType("Outer_X")]
    public class Outer
    {
        public Outer()
        {
            this.InnerItem = new InnerX();
        }
        [XmlElement(typeof(InnerX))]
        [XmlElement(typeof(Inner))] // Necessary to inform the serializer of polymorphism even though Inner is abstract.
        public Inner InnerItem { get; set; }
    }
    public abstract class Inner
    {
    }
    [XmlType("Inner_X")]
    public class InnerX : Inner
    {
    }
