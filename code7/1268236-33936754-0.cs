    public string IdsColumn { get; set; } // Mapped to DB
    [NotMapped]
    public List<int> Ids
    {
        get { return Deserialize(IdsColumn); }
        set { IdsColumn = Serialize(value); }
    }
