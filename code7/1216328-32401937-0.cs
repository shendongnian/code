        [DataContract(Namespace = "urn:UMARKETSPIWS:v2")]
        public class KeyValuePair
        {
            [DataMember(Name = "key", Order = 0)]
            public string key { get; set; }
            [DataMember(Name = "value", Order = 1)]
            public string value { get; set; }
        }
