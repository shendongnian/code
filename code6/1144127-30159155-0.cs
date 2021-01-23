    [DataContract(Namespace = "http://www.labels.com/label")]
    public class RequestData
    {
        [DataMember] // Notice that "Name" is not set
        public string labelDetail { get; set; }
    }
