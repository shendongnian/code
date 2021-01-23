    [KnownType(typeof(Contact)), KnownType(typeof(Apps)), KnownType(typeof(Person))]
        [DataContract]
        public abstract class Node
        {
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public string url { get; set; }
    
            [DataMember]
            public string description { get; set; }
    
            [DataMember]
            public List<Action> actions { get; set; }
            public virtual void AddComment()
            {
    
            }
            public virtual void AddContact()
            {
    
            }
        }
