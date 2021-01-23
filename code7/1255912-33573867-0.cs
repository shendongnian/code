    [DataContract]
    [KnownType(typeof(Test1Class))]
    [KnownType(typeof(Test2Class))]
    public class TestBaseClass
    {
        [DataMember]
        public string baseproperty { get; set; }
    }
