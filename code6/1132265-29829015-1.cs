    private string codigo;
    [Key]
    [StringLength(20)]
    public string Codigo
    {
        get { return codigo.Capitalize(); }
        set { codigo = value; }
    }
