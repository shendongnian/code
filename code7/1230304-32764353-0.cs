     [DataContract]
        public class RootObject
        {
            [DataMember(Name = "odata.metadata")]
            public string metadata { get; set; }
            [DataMember]
            public List<ActiveDirectorySchemaExtension> value { get; set; }
        }
