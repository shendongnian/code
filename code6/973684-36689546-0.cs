    [XmlRoot]
    public class SomeAccount
    {
        [XmlIgnore]
        public ItemChoiceType EnumType;
        [XmlChoiceIdentifier("EnumType")]
        [XmlElement("LeParentId")]
        [XmlElement("parentId")]
        public long ParentId { get; set; }
        
        //rest of fields...
    } 
    [XmlType(IncludeInSchema = false)]
    public enum ItemChoiceType
    {
        LeParentId,
        parentId
    }
