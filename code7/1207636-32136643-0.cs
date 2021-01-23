    namespace ClassLibrary1
    {
        [DataContract]
        [KnownType(typeof(BaseClass))]
        [KnownType(typeof(Derived))]
        public class BaseClass
        {
            [DataMember]
            public string BaseString { get; set; }
        }
    }
    namespace ClassLibrary2
    {
        [DataContract]
        [KnownType(typeof(BaseClass))]
        [KnownType(typeof(Derived))]
        public class Derived : BaseClass
        {
            [DataMember]
            public string DerivedString { get; set; }
        }
    }
