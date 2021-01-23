    public class Groups
    {
        public Groups()
        {
            group = new List<Group>();
        }
    
        [XmlElement("Group")]
        public List<Group> group { get; set; }
    }
     
