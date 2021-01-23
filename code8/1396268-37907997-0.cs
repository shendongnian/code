    [DataContract]
    public class EmailEntity
    {
        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public string body { get; set; }
    }
