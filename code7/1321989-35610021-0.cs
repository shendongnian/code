    [DataContract]
    public class Results
        {
            [DataMember]
            public string categoryName { get; set; }
    
            [DataMember]
            public List<Object> results { get; set; }
        }
