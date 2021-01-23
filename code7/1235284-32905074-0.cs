    public MyModel 
    { 
        public long Id { get; set; }
    
        // Even if database column 'Value' could be NULL,
        // the model - from business view - could not.
        public long? Value { get; set; }
    }
