    [DataContract]
    class MyResource
    {
        // Don't mark these with [DataMember]
        public string SpecialName { get; set; }
        public string SpecialValue { get; set; }
        [DataMember(Name = "rel")]
        public string Rel { get; set; }
    }
