    [DataContract]
    [KnownType(typeof(concreteClass1))]
    [KnownType(typeof(concreteClass2))]
    public abstract class BaseClass
    {
        // remove abstract from property
        [DataMember]
        public string id { get; set; }
    }
    [DataContract(Name = "class1")]
    public class concreteClass1 : BaseClass
    {
        public concreteClass1() { }
        // you dont need this property coz it is inherited from BaseClass
        //[DataMember]
        //public override string id { get; set; }
        [DataMember]
        public string prop1 { get; set; }
        [DataMember]
        public string prop2 { get; set; }
    }
    [DataContract(Name = "class2")]
    public class concreteClass2 : BaseClass
    {
        public concreteClass2() { }
        // you don't need this property coz it is inherited from BaseClass
        //[DataMember]
        //public override string id { get; set; }
        [DataMember]
        public string prop1 { get; set; }
        [DataMember]
        public string prop2 { get; set; }
    }
