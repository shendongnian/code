    [DataContract]
    public class Account
    {
        [DataMember, XmlAttribute]
        public string Name { get; set; }
        [DataMember]
        public double Balance { get; set; }
    }
