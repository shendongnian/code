    public class ProductViewModel
    {
         private Product product;
         private List<Account> account;
    
         public ProductViewModel(Product product, List<Account> account)
         {
              this.product = product;
              this.account = account;
         }
    
         public bool ValidAccountForProduct
         {
              get
              {
                   var result = account.Where(i => i.Role == 3 || i.Role == 1);
                   if(result.Any())
                       return true;
              
                   return false;
              }
         }
    }
