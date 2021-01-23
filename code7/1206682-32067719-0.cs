    [DataContract]
    public class BaseType
    {
        [DataMember]
        public string zebra;
    }
    [DataContract]
    public class DerivedType : BaseType
    {
        [DataMember(Order = 0)]
        public string bird;
        [DataMember(Order = 1)]
        public string parrot;
        [DataMember]
        public string dog;
        [DataMember(Order = 3)]
        public string antelope;
        [DataMember]
        public string cat;
        [DataMember(Order = 1)]
        public string albatross;
    }
