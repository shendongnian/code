    [DataContract(Name = "Sample", Namespace = "")]
    public class Sample
    {
        [DataMember(Name = "AccountId")]
        public string AccountId { get; set; }
        [DataMember(Name = "AccountNumber")]
        public string AccountNumber { get; set; }
    }
    [DataContract(Name = "Invoice", Namespace = "")]
    public class Invoice
    {
        [DataMember(Name = "Samples")]
        public List<Sample> Samples { get; set; }
    }
