    [DataContract]
    [KnownType(typeof(concreteClass1))]
    [KnownType(typeof(concreteClass2))]
    public abstract class BaseClass
    {
        [DataMember]
        public abstract string id { get; set; }
    }
    [DataContract(Name = "class1")]
    public class concreteClass1 : BaseClass
    {
        public concreteClass1() { }
        [DataMember]
        public override string id { get; set; }
        [DataMember]
        public string prop1 { get; set; }
        [DataMember]
        public string prop2 { get; set; }
    }
    [DataContract(Name = "class2")]
    public class concreteClass2 : BaseClass
    {
        public concreteClass2() { }
        [DataMember]
        public override string id { get; set; }
        [DataMember]
        public string prop1 { get; set; }
        [DataMember]
        public string prop2 { get; set; }
    }
