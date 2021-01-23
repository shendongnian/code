    [DataContract]
    public class WcfData
    {
        [DataMember]
        public WcfDataNested NestedData { get; set; }
        public class WcfDataNested
        {
            [DataMember]
            public string Foo { get; set; }
            [DataMember]
            public string Bar { get; set; }
        }
    }
