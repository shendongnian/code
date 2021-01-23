     public class DashboardData
     {
             public DBEntities db = new DBEntities();
             public List<ProductTableViewModel> GetAllProducts()
             {
                   var result = (from product in db.AB_Product
                                    .....
                                 select new ProductTableViewModel
                                 {
                                 .....     
                                 }).ToList();
        
                   return result;
             }
     }
