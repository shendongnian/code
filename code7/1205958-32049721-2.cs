    [DataContract(Namespace = Namespaces.Example)]
    public class MyHeader
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    
    }
