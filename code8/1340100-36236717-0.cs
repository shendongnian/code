    [XmlRoot(ElementName = "member", Namespace = "urn:epcglobal:ale:xsd:1")]
    public class Member
    {
        [XmlElement(ElementName = "tag", Namespace = "urn:epcglobal:ale:xsd:1")]
        public string Tag { get; set; }
    }
    [XmlRoot(ElementName = "groupList", Namespace = "urn:epcglobal:ale:xsd:1")]
    public class GroupList
    {
        [XmlElement(ElementName = "member", Namespace = "urn:epcglobal:ale:xsd:1")]
        public Member Member { get; set; }
    }
    [XmlRoot(ElementName = "groupCount", Namespace = "urn:epcglobal:ale:xsd:1")]
    public class GroupCount
    {
        [XmlElement(ElementName = "count", Namespace = "urn:epcglobal:ale:xsd:1")]
        public string Count { get; set; }
    }
    [XmlRoot(ElementName = "group", Namespace = "urn:epcglobal:ale:xsd:1")]
    public class Group
    {
        [XmlElement(ElementName = "groupList", Namespace = "urn:epcglobal:ale:xsd:1")]
        public GroupList GroupList { get; set; }
        [XmlElement(ElementName = "groupCount", Namespace = "urn:epcglobal:ale:xsd:1")]
        public GroupCount GroupCount { get; set; }
    }
    [XmlRoot(ElementName = "report", Namespace = "urn:epcglobal:ale:xsd:1")]
    public class Report
    {
        [XmlElement(ElementName = "group", Namespace = "urn:epcglobal:ale:xsd:1")]
        public Group Group { get; set; }
        [XmlAttribute(AttributeName = "reportName")]
        public string ReportName { get; set; }
    }
    [XmlRoot(ElementName = "reports", Namespace = "urn:epcglobal:ale:xsd:1")]
    public class Reports
    {
        [XmlElement(ElementName = "report", Namespace = "urn:epcglobal:ale:xsd:1")]
        public List<Report> Report { get; set; }
    }
    [XmlRoot(ElementName = "ECReports", Namespace = "urn:epcglobal:ale:xsd:1")]
    public class ECReports
    {
        [XmlElement(ElementName = "reports", Namespace = "urn:epcglobal:ale:xsd:1")]
        public Reports Reports { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "schemaVersion")]
        public string SchemaVersion { get; set; }
        [XmlAttribute(AttributeName = "creationDate")]
        public string CreationDate { get; set; }
        [XmlAttribute(AttributeName = "specName")]
        public string SpecName { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "ALEID")]
        public string ALEID { get; set; }
        [XmlAttribute(AttributeName = "totalMilliseconds")]
        public string TotalMilliseconds { get; set; }
        [XmlAttribute(AttributeName = "terminationCondition")]
        public string TerminationCondition { get; set; }
    }
