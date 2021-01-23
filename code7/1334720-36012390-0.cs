    [Serializable]
    public class OrderXML
    {
        [XmlElement("GROUPLIST", Type = typeof(Group))]
        public Group[] GroupList { get; set; }
    }
