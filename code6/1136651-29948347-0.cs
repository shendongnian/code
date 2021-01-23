    [Serializable]
    [DataContract]
    [
       KnownType(typeof(DerivedClass1)), 
       KnownType(typeof(DerivedClass2))
    ]
    public class BaseClass
    {
    }
    public class DerivedClass1:BaseClass
    {
    }
    public class DerivedClass2:BaseClass
    {
    }
