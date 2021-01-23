    [DataContract(Namespace = "http://customnamespace")]
        public class Result
        {
            [DataMember]
            public string Bla { get; set; }
    
            [DataMember]
            public IdsList List { get; set; }
        }
