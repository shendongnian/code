    [DataContract]
    public class WrapClienti
    { 
        [DataMember(Order=1)]
        public string CAP { get; set; } 
    
        [DataMember(Order=2)]
        public string PROV { get; set; } 
        ...etc
    }
