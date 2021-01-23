       [DataContract]
       public class Person
       {
            
            [DataMember(Name = "Name", Order = 1)]
            public string Name{ get; set; }
            
            [DataMember(Name = "Phone", Order = 2)]
            public string Phone{ get; set; }
            
            [DataMember(Name = "List Item 1", Order = 3)]
            public List<string> ListItem1 { get; set; }
        
            [DataMember(Name = "List Item 2", Order = 4)]
            public List<string> ListItem2 { get; set; }
        
            [DataMember(Name = "List Item 3", Order = 5)]
            public List<string> ListItem3 { get; set; }
       }
