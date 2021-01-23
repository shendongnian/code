    [DataContract]
    [KnownType(typeOf(Customer)]
    public abstract class GenericType
    {
    }
    
    [DataContract]
    public class Customer : GenericType
    {
    }
