    public class Groups
    {
        public Groups()
        {
            Group = new List<Group>();
        }
        [XmlArray("ArrayOfGroup")]
        public List<Group> Group { get; set; }
    }
    public class Group
    {
        public Guid GroupRef;
        public string Name;
        public string Description;
    }
