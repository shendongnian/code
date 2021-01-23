    [XmlRoot("finPOWERConnect")]
    public class ApplicationData
    {
        [XmlElement("finAccount")]
        public List<Account> Accounts {get; set; }
    }
    [XmlRoot("finAccount")]
    public class Account
    {
        [XmlAttribute("version")]
        public string Version { get; set; } 
        //Account stuff
    }
    ​
