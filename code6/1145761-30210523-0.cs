    [DataContract]
    [KnownType(typeof(int)]
    //same way add here all the types that you are using in your class A
    class ClassA
    {
        [DataMember]
        public int Value;
        ...
    }
