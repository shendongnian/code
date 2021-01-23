    [DataContract]
    public class ClassA<T>
    {
        [DataMember]
        public T PropertyA { get; set; }
        [DataMember]
        public int PropertyB { get; set; }
    }
    // No need to override PropertyA since T is int and ClassB
    // inherits both PropertyA and PropertyB...
    [DataContract]
    public class ClassB : ClassA<int>
    {
    }
