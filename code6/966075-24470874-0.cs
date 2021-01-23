    using System.Xml.Serialization;    
    [XmlRootAttribute("ViewState")]
    class ViewState
    {
       [XmlAttribute("ID")
       public string ID { get; set; }
       
       [XmlArray("Attributes")]
       [XmlArrayItem("Attribute")]
       public List<Attribute> Attributes { get; set; }
    }
    [XmlRootAttribute("Attribute")]
    class Attribute
    {
       [XmlAttribute("Key")]
       public string Key { get; set; }
       [XmlAttribute("Value")]
       public string Value { get; set; }
    }
