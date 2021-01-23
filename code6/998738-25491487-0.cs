    public int MappingId { get; set; }
    public int CategoryId { get; set; }
    public int OptionId { get; set; }
    [ReadOnlyColumn]
    public string CategoryName { get; set; }
