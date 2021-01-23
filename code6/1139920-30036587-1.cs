    [DataContract(Name="Root")]
    public class Root
    {
       [DataMember(Name="Test")] // Changed this
       public List<Test> TestList { get; set; }
    }
