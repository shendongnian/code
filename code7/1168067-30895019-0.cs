    [XmlRoot]
    public class Response
    {
        [XmlElement("Make")] // Use XmlElement to get multiple items without a containing XML tag
        public List<Make> Make { get; set; } 
    }
    public class Spec
    {
        [XmlAttribute("YearProductionStarts")]
        public string YearProductionStarts { get; set; }
        [XmlAttribute("YearProductionEnd")]
        public string YearProductionEnd { get; set; }
    }
    public class Make
    {
        [XmlElement("Model")]
        public List<Model> Model { get; set; }
    }
    public class Model
    {
        [XmlArray("Specs"), XmlArrayItem("Spec")]
        public List<Spec> Spec { get; set; }
    }
