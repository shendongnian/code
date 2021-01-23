    private List<Accessories> _accessory;
    
    public string Model { get; set; }
    public string CarType { get; set; }
    public List<Accessories> Accessory
    {
        get { return _accessory ?? (__accessory = new List<Accessories>();)}
    }
    public string Price { get; set; }
