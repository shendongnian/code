    public interface IWithInvolvedDomainObjects 
    {
         IEnumerable<Type> LatestInvolvedDomainObjectTypes { get; }
    }
    public interface IPurchaseRepository : IWithInvolvedDomainObjects 
    {
         IEnumerable<PurchaseOrder> GetPurchaseOrders();
    }
    
    public class PurchaseRepository : IPurchaseRepository
    {
          public IEnumerable<Type> LatestInvolvedDomainObjectTypes { get; private set; }
    
          public IEnumerable<PurchaseOrder> GetPurchaseOrders()
          {
               LatestInvolvedDomainObjectTypes = new[]
               {
                    typeof(PurchaseOrder)
               };
              
               return testContext.PurchaseOrders
                   .Include(order => order.CompanyAccountingCodeNumber)
                   .Include(order => order.CompanyAccountingCodeNumber.AccountingCode);
    
          }
    }
