    [DataContract]
    public class MyDomainModel
    {
        [DataMember]
        public string PublicString { get; set; }
        public string HiddenString { get; set; }
        public MyDomainModel InfiniteReference { get; set; }
    }
