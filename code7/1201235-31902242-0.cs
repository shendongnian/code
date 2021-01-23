    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/WcfWebService")]
    public class WS_IN_GetAccountCredit
    {
        [DataMember]
        public GetAccountCreditParams GetAccountCreditParams { get; set; }
        [DataMember]
        public WSIdentity WSIdentity { get; set; }
    }
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/WcfWebService")]
    public class GetAccountCreditParams
    {
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/WcfWebService")]
    public class WSIdentity
    {
        [DataMember]
        public string WS_PassWord { get; set; }
        [DataMember]
        public string WS_UserName { get; set; }
    }
