    [XmlRoot("input")] //indicate that this class represents the xml file
    public class CommandList
    {   
        // tell the XmlSerializer which <element> belongs to which class.
        [XmlElement("repeat", typeof(Repeat))]
        [XmlElement("reverse", typeof(Reverse))]
        [XmlElement("inverse", typeof(Inverse))]
        public List<Command> Commands { get; } = new List<Command>();
    }
