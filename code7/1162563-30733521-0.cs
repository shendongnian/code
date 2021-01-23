    public override string UserName { get; set; }
    
    [NotMapped]
    public string UserNameDisplay
    {
        get { return UserName ?? "anonymous"; }
        set { UserName = value; }
    }
