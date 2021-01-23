    [XmlRoot("CustomField")]
    public class CustomField
    {
        [XmlAttribute("FieldID")]
        public string FieldID;
        [XmlAttribute("FieldValue")]
        public string FieldValue;
        public CustomField() { }
        public CustomField(string fieldID, string fieldValue)
        {
            this.FieldID = fieldID;
            this.FieldValue = fieldValue;
        }
    }
    [XmlRoot("Entry")]
    public class CustomEntry
    {
        [XmlAttribute("Author")]
        public string Author;
        [XmlAttribute("Title")]
        public string Title;
        [XmlAttribute("Trial")]
        public string Trial;
        [XmlAttribute("Responses")]
        public List<CustomField> Responses;
        public CustomEntry() { }
    }
    ​
