    // Instantiate your class and at the same time make PosOrcSerProStatus a new list
    public PostOrcamentoServicoProposta()
    {
      PosOrcSerProStatuses = new List<PosOrcSerProStatus>();
    }
    
    // Also make PosOrcSerProStatuses a virtual ICollection
    public virtual ICollection<PosOrcSerProStatus> PosOrcSerProStatuses { get; set; }
