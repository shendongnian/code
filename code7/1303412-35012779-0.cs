    public int Deleted { get; set; }
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public bool IsDeleted
    {
        get { return Deleted == 1; }
        set { Deleted = value ? 1 : 0; }
    }
