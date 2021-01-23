    public class OrderXML
        {
            [XmlElement(ElementName = "GROUPLIST")]
            public GroupList GroupList { get; set; }
        }
        public class GroupList
        {
            [XmlElement(ElementName = "GROUP", Type = typeof(Group))]
            public Group[] Groups { get; set; }
    
        }
