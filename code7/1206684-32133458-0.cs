    [DataContract]
    public class BaseType
    {
        [DataMember]
        public virtual string zebra { get; set; }
    }
    [DataContract]
    public class DerivedType : BaseType
    {
        [DataMember]
        public override string zebra { get; set; }
        [DataMember]
        public string bird { get; set; }
        [DataMember]
        public string parrot { get; set; }
        [DataMember]
        public string dog { get; set; }
        [DataMember]
        public string antelope { get; set; }
        [DataMember]
        public string cat { get; set; }
        [DataMember]
        public string albatross { get; set; }
    }
