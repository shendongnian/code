    [XmlIgnore]
    public IdTag ParentIdTag { get; set; }
    [XmlAttribute]
    public string ParentId 
    { 
        get { return ParentIdTag.id; } 
        set { ParentIdTag.id = value; } 
    }
