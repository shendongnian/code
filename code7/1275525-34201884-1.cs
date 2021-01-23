    [DataContract]
    [KnownType(typeof(SomeUnit))]
    public class BaseClass
    {
        ...
    }
    [DataContract]
    public class SomeUnit : BaseClass
    {
        ...
    }
