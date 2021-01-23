    [DataContract]
    public class HelloWorldAsk
    {
        [DataMember]
        public string MyName { get; set; }
        [DataMember]
        public string MyEmail { get; set; }
    }
    [DataContract]
    public class HelloWorldResponse
    {
        [DataMember]
        public string YourName { get; set; }
        [DataMember]
        public string YourId { get; set; }
    }
