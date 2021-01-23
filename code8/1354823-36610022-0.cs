    public class Document
    {
        public string NameOfHolder { get; set; }
        public string DateOfExpiry { get; set; }
        public List<string> Features { get; set; }
        public List<int> Typegroups { get; set; }
    }
    public class ScanListItem
    {
        public string SessionId { get; set; }
        public string InstanceId { get; set; }
        public string ClientId { get; set; }
        public string DeviceId { get; set; }
       public Document document { get; set; }
    }
