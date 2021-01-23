    public class Contract
    {
      public Contract()
      {
        this.Contracts  = new List<Contract>();
      }
      public int Id { get; set; }
    
      public int? ContractParentId
      {
        get; set; 
      }
      public Contract ContractParent { get; set; }
      public List<Contract> Contracts { get; set; }
    }
