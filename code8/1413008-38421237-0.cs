    [DataContract]
    public class GroupProvider
    {
        [DataMember]
        public int Group { get; set; }
        [DataMember]
        public DataGroupProvider[] data { get; set; }
    }
    [DataContract]
    public class DataGroupProvider
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string ProviderName { get; set; }
        [DataMember]
        public int ProviderNo { get; set; }
    }
