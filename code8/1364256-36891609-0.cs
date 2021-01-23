    [DataContract(Name = "alert", Namespace = "")]
    public class Alert
    {
        [DataMember(Name = "identifier")]
        public string identifier { get; set; }
    
        [DataMember(Name = "info")]
        public KeyValuePair<string, string> Info { get; set; }
    }
	var alert = new Alert()
    {
        Identifier = "SecretID",
        Info = new KeyValuePair<string, string>()
    }
