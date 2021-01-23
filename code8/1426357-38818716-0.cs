    [DataContract]
    public class Token
    {
        [DataMember("RAX-AUTH:authenticatedBy")]
        public string[] AuthenticatedBy { get; set; }
        [DataMember("expires")]
        public DateTime Expires { get; set; }
        [DataMember("id")]
        public string Id { get; set; }
    }
