    [DataContract]
    public class Project
        {  
            [DataMember]
            public int ID { get; set; }
            [DataMember(Name="ClientId")]        
            public int Client_ID { get; set; }
            [DataMember]        
            public string Name { get; set; }
            [DataMember]        
            public string code { get; set; }
            [DataMember]        
            public bool active { get; set; }
            [DataMember]        
            public bool billable  { get; set; }
            [DataMember]        
            public string bill_by { get; set; }
        }
