    public int ID { get; set; }
    public int DemandingEmployeeID { get; set; }
    public int RequestedEmployeeID { get; set; }
    
    public virtual Employee DemandingEmployee { get; set; }
    public virtual Employee RequestedEmployee { get; set; }
