    public string ItemsString { get; set; }
    [NotMapped]
    public string Items
    {
        get { return FillFromString(ItemsString); }
        set { ItemsString = value.ToString(); }
    }
