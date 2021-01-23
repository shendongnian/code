    public string ModifiedBy { get; set; }
    
    [DataMember]
    [ForeignKey("ModifiedBy")] 
    public User ModifiedUser
            {
                get;
                set;
            }
