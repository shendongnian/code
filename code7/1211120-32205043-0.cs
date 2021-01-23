    [DataContract]
    public  class Customer
    {
        [DataMember(Order = 1)]
        public string Date{ get; set; }
        [DataMember(Order = 2)]
        public string InstallationNo{ get; set; }
        [DataMember(Order = 3)]
        public string SerialNo { get; set; }        
    } 
