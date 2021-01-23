    [DataContract]
    public class Token
    {
        [DataMember(Name = "RAX-AUTH:authenticatedBy")]
        public string[] AuthenticatedBy { get; set; }
        [DataMember(Name = "expires")]
        public DateTime Expires { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
