    [DataContract]
    public class Login
    {
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string[][] MessageList { get; set; }
    }
