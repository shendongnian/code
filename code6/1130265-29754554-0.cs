    [XmlRoot("item", Namespace = "")] // Applies when an Item is the document root.
    [XmlType("item", Namespace = "")] // Applies when an Item is not the document root.
    public class Item
    {
        [XmlElement("location", Namespace = "Athens")]
        public string Location { get; set; }
    }
