    [DataContract(Name = "WaitForClientMessagesResult", Namespace = "http://schemas.datacontract.org/2004/07/Data.WebGateway")]
    public class WaitForClientMessagesResult
    {
        public WaitForClientMessagesResult() { }
        [DataMember(Name = "WaitForClientMessagesResult")]
        public WebClientMessage[] Messages { get; set; }
    }
