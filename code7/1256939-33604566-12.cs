    [DataContract]
    public class RetrieveSanctionPartyList
    {
        [DataMember]
        public string Spl { get; set; }
        [DataMember]
        public string Tech { get; set; }
        [DataMember]
        public string PartnerId { get; set; }
    }
