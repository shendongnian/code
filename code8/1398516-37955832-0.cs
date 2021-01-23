    {
        [DataContract]
        public class LanguagePair
        {
            [DataMember]
            public string Key { get; set; }
            [DataMember]
            public string Value { get; set; }
            [DataMember]
            public string Version { get; set; }
        }
    }
