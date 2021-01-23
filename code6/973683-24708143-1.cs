    [XmlRoot]
    public class SomeAccount
    {
        [XmlElement("parentId")]
        [XmlSynonymDeserializer.Synonyms("LeParentId", "AnotherGreatName")]
        public long ParentId { get; set; }
        //rest of fields...
    }
    
