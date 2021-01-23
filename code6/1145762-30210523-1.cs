    [DataContract]
    [KnownType(typeof(int))]
    // Same way add here all the types that you are using in your class A.
    class ClassA
    {
        [DataMember]
        public int Value;
        ...
    }
