    public Class City
    {
        public long ID { get; set }
        ...
        public int StateID 
        {
             get
             {
                 return State.ID;
             }
        }
    
        [JsonIgnore]
        public State State { get; set; }
        ...
    }
