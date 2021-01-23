    [XmlRoot]
    public class SomeAccount
    {
        [XmlElement("parentId")]
        public long ParentId { get; set; }
        [XmlElement("LeParentId")]
        public long LeParentId { get { return this.ParentId; } set { this.ParentId = value; } }
        //rest of fields...
    }
