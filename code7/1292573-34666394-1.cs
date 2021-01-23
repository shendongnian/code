    public int id { get; set; }
    [JsonIgnore]
    public List<AnotherClass> field1s { get; set; }
    public List<string> field1
    {
        get{return field1s.Select(f=>f. subfieldValue).ToList();}
        set{}
    }
