    Organisation
    //CEO
    public int IdCeo { get; set; }
    [ForeignKey("IdCeo")]
    public virtual Person CEO { get; set; }
    //CFO
    public int IdCfo { get; set; }
    [ForeignKey("IdCfo")]
    public virtual Person CFO { get; set; }
