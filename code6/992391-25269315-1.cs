    public class SupplierCompany : Company
    {
       public SupplierCompany()
       {
         EntityType = CompanyType.Supplier;
       }
       public override void Invoice()
       {...}
       public override void GetComission(int month)
       {...}
    }
    
    public class AgentCompany : Company
    {
       public AgentCompany()
       {
         EntityType = EntityType.Agent;
       }
       public override void Invoice()
       {...}
       public override void GetComission(int month)
       {...}
    }
