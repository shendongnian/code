       [DataContract]
        public class Activity
        {
            [DataMember]
            public String Status
            {
                get; set;
            }
    
            [DataMember]
            public String Name
            {
                get; set;
            }
    
            [DataMember]
            public DateTime StartTime { get; set; }
        }
