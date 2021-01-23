    public Class City
    {
        public long ID { get; set }
        ...
        [ScriptIgnore]
        public State State { get; set; }
        ...
    }
