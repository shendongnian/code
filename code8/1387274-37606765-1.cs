    [DataContract(Name = "ValidationResult", Namespace = "")]
    public class ValidationResult
    {
        [DataMember(Order = 0)]
        public string Message { get; set; }
        [DataMember(Order = 1)]
        public string Id { get; set; }
        [DataMember(Order = 2)]
        public string Target { get; set; }
    }
