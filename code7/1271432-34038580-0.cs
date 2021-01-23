    public class DashboardViewModel
    {
        public List<ProductTableViewModel>  ProductTable;
    
        public NewProductViewModel NewProduct;
    
        public DiscussionsViewModel Discussions;
    }
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
