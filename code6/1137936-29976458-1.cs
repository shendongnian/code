    public Class City
    {
        public long ID { get; set }
        ...
        [JsonIgnore]
        public State State { get; set; }
        ...
    }
