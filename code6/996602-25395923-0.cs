    [DataContract(Namespace = "http://namespacename/")]
    public class Customer
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public CustomerAddress { get; set; }
        [DataMember]
        public CustomerContact { get; set; }
        // Other properties as desired/needed\
    }
