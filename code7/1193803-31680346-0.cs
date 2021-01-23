    using System.Runtime.Serialization;
    
    [DataContract]
    class MyClass
    {      
        [DataMember]
        protected double field1; // This field is serialized
        
        protected double secretField; // This field is not        
    }
