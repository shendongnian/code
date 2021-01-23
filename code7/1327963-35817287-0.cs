    [XmlRoot("TransactionLog")]
    public class TransactionLogModel
    {
        [XmlElement("RuleViolations")]
        public List<RuleViolation> RuleViolations { get; set; }
    }
    public class RuleViolation
    {
        public RuleViolation() { this.Errors = new List<Error>(); }
        [XmlElement("error")]
        public List<Error> Errors { get; set; }
    }
    public class Error
    {
        [XmlElement("message")]
        public string Message { get; set; }
        // To be done.
        public List<KeyValuePair<string, string>> Keys { get; set; }
    }
