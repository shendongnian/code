    [XmlRoot("specifications")]
        public class Specifications
        {
             [NonSerialized]
             Dictionary<string, string> dict { get; set; }
             [XmlElement("color")]
             string color {get;set;}
             [XmlElement("length")]
             string length { get; set; }
             [XmlElement("width")]
             string width { get; set; }
             public Specifications()
             {
                 dict = new Dictionary<string, string>();
             }
        }
