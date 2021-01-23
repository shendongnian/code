    [XmlRoot("Groups"), XmlType("Groups")]
    public class GroupRoot
    {
        [XmlElement(ElementName = "Group")]
        public List<Group> Group { get; set; }
    }
