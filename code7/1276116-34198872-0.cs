    [DataContract]
    public class Parameter
    {
        [DataMember(Order = 0)]
        public string PolicyNumber { get; set; }
        [DataMember(Order = 1)]
        public DateTime EffectiveDate { get; set; }
        [DataMember(Order = 2)]
        public DateTime ExpirationDate { get; set; }
    }
