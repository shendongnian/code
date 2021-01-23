    [Serializable()]
    [XmlRoot("component", Namespace="", IsNullable=false)]
    public class Component {
        [XmlAttribute("name")] public string Name { get; set;}
    }
    [Serializable()]
    [XmlRoot("composite", Namespace="", IsNullable=false)]
    public class Composite : Component {
        [XmlElement("component", typeof(Component))]
        [XmlElement("composite", typeof(Composite))]
        public object[] Items { get; set; }
    }
