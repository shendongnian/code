    [XmlRoot(ElementName = "import")]
    public class Import
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "operation")]
        public string Operation { get; set; }
        [XmlAttribute(AttributeName = "entity")]
        public string Entity { get; set; }
        [XmlAttribute(AttributeName = "externalReference")]
        public string ExternalReference { get; set; }
        [XmlAttribute(AttributeName = "item")]
        public string Item { get; set; }
        [XmlAttribute(AttributeName = "queryTime")]
        public string QueryTime { get; set; }
        [XmlElement(ElementName = "failureMessage")]
        public string FailureMessage { get; set; }
        [XmlElement(ElementName = "failureDetail")]
        public string FailureDetail { get; set; }
        [XmlElement(ElementName = "duplicateMessage")]
        public string DuplicateMessage { get; set; }
        [XmlElement(ElementName = "duplicateDetail")]
        public string DuplicateDetail { get; set; }
    }
    [XmlRoot(ElementName = "importSuccesses")]
    public class ImportSuccesses
    {
        [XmlElement(ElementName = "import")]
        public List<Import> Import { get; set; }
    }
    [XmlRoot(ElementName = "importFailures")]
    public class ImportFailures
    {
        [XmlElement(ElementName = "import")]
        public Import Import { get; set; }
    }
    [XmlRoot(ElementName = "importDuplicates")]
    public class ImportDuplicates
    {
        [XmlElement(ElementName = "import")]
        public Import Import { get; set; }
    }
    [XmlRoot(ElementName = "importResult")]
    public class OrderImportResponse
    {
        [XmlElement(ElementName = "importSuccesses")]
        public ImportSuccesses ImportSuccesses { get; set; }
        [XmlElement(ElementName = "importFailures")]
        public ImportFailures ImportFailures { get; set; }
        [XmlElement(ElementName = "importDuplicates")]
        public ImportDuplicates ImportDuplicates { get; set; }
    }
