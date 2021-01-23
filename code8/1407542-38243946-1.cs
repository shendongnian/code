    [DataContract]
    [KnownType(typeof(ParentA))]
    [KnownType(typeof(ParentB))]
    public class Parent  {}
    [DataContract(Name="ParentA")]
    public class ParentA : Parent { 
      [DataMember(Name="id")]
      public int Id { get; set; }
    }
