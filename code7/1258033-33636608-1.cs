    [DataContract]
    public class AuthToken 
    {
        [DataMember(Name = ".expires")]
        public long expires_in { get; set; }
    }
