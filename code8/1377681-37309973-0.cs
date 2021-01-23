    [XmlRoot(ElementName = "Options")]
    public class Options
    {
        [XmlElement(ElementName = "Option")]
        public List<string> Option { get; set; }
    }
    [XmlRoot(ElementName = "Specs")]
    public class Specs
    {
        [XmlElement(ElementName = "Section")]
        public string Section { get; set; }
        [XmlElement(ElementName = "Options")]
        public Options Options { get; set; }
    }
    [XmlRoot(ElementName = "Menus")]
    public class Menus
    {
        [XmlElement(ElementName = "Specs")]
        public Specs Specs { get; set; }
    }
    [XmlRoot(ElementName = "Mailbox")]
    public class Mailbox
    {
        [XmlElement(ElementName = "Menus")]
        public Menus Menus { get; set; }
    }
