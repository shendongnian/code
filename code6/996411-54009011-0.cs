    [DataContract(Namespace = OperatorNameMessageHeader.HeaderNamespace)]
    public class OperatorNameMessageHeader
    {
        public const string HeaderName = "OperatorNameMessageHeader";
        public const string HeaderNamespace = "http://schemas.microsoft.com/scout";
        [DataMember]
        public string OperatorName { get; set; }
    }
