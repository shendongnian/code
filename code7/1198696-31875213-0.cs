    [DataContract]
    public class A : ISomeInterface
    {
    
    }
    
    [KnownType(typeOf(A))]
    [DataContract]
    public Class B: 
    {
       [DataMember]
       public A { get; set;}
    } 
