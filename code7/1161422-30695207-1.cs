    public class Customer
    {
      public int Id {get;set;}
      //...
    }
    public class Era 
    {
      public int Id {get;set;}
      //...
    }
    public class CompanyCode 
    {
      public int Id {get;set;}
      //...
    }
    public class Bill
    {
      [Key] 
      [Column(Order=1)] 
      [ForeignKey("Customer")]
      public int CustomerId {get;set;}
      [Key] 
      [Column(Order=2)] 
      [ForeignKey("Era")]
      public int EraId {get;set;}
      [Key] 
      [Column(Order=3)] 
      [ForeignKey("CompanyCode")]
      public int CompanyCodeId {get;set;}
      //...
      public virtual Customer Customer { get; set; }
      public virtual Era Era { get; set; }
      public virtual CompanyCode CompanyCode { get; set; }
    }
