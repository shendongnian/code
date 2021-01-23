    [DataContract]
    [KnownType(typeof(SomeUnit))]
    public class Wrapper
    {
        [DataMember]
        public IUnit Value { get; set; }
    }
    [DataContract]
    public class SomeUnit : IUnit
    {
        ...
    }
