    [XmlRoot(ElementName = "comment")]
    public class Comment
    {
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
    [XmlRoot(ElementName = "title_block")]
    public class Title_block
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "company")]
        public string Company { get; set; }
        [XmlElement(ElementName = "rev")]
        public string Rev { get; set; }
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "comment")]
        public List<Comment> Comment { get; set; }
    }
    [XmlRoot(ElementName = "sheet")]
    public class Sheet
    {
        [XmlElement(ElementName = "title_block")]
        public Title_block Title_block { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "tstamps")]
        public string Tstamps { get; set; }
    }
