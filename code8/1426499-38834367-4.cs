    [DataContract]
    public class TestClass
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember(Name = "request_name")]
        public string RequestedName { get; set; }
        [DataMember(Name = "request_type")]
        public string RequestType { get; set; }
        [DataMember(Name = "request_key")]
        public string RequestKey { get; set; }
        [DataMember(Name = "descriptive_name")]
        public string DescriptiveName { get; set; }
        [DataMember(Name = "owner_internal_id")]
        public string OwnerInternalId { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public Status Status { get; set; }
        [DataMember]
        public DateTime? Created { get; set; }
        [DataMember]
        public DateTime? Modified { get; set; }
    }
