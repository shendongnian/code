    [OneToMany]
    public List<City> Cities { get; set; }
    [ManyToOne]
    public Country Co { get; set; }
    [ManyToOne]
    public City Ci { get; set; }
