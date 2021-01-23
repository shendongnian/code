    [DataContract(Name="BaseClass")]
    public class Derived : BaseClass 
        [DataMember]
        public string DerivedString { get; set; }
    }
