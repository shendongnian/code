    [XmlRoot("item")]
    public abstract class Item
    {
        [XmlElement("make")]
        public string Make { get; set; }
    }
    [XmlRoot("item")]
    public class Bicycle : Item
    {
        [XmlElement("frameSerialNo")]
        public string FrameSerialNumber { get; set; }
    }
    [XmlRoot("item")]
    public class Car : Item
    {
        [XmlElement("registration")]
        public string Registration { get; set; }
    }
    public class ItemList
    {
        public List<Item> Items { get; set; }
    }
