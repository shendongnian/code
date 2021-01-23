    public class GroupFile
    {
        [XmlElement("Group")]
        public Group[] Groups { get; set; }
    }
    public class Group
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("Member")]
        public Member[] Members { get; set; }
    }
    public class Member
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlText]
        public string MemberValue { get; set; }
    }
